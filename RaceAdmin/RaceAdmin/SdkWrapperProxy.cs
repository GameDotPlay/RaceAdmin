using iRacingSdkWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RaceAdmin
{
    /// <summary>
    /// Provides a passthrough proxy implementation of the ISdkWrapper interface which 
    /// simply delegates to the SdkWrapper provided in the constructor.
    /// </summary>
    public class SdkWrapperProxy : ISdkWrapper
    {
        private readonly SdkWrapper wrapper;
        private readonly bool record;
        private string sessionLogPath;

        private List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers;
        private List<EventHandler<ITelemetryUpdatedEvent>> telemetryUpdateHandlers;

        public SdkWrapperProxy(SdkWrapper wrapper, bool record)
        {
            this.wrapper = wrapper;
            this.record = record;

            wrapper.TelemetryUpdated += OnTelemetryUpdate;
            wrapper.SessionInfoUpdated += OnSessionInfoUpdate;

            sessionInfoUpdateHandlers = new List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>>();
            telemetryUpdateHandlers = new List<EventHandler<ITelemetryUpdatedEvent>>();
        }

        public void AddTelemetryUpdateHandler(EventHandler<ITelemetryUpdatedEvent> handler)
        {
            telemetryUpdateHandlers.Add(handler);
        }

        public void OnTelemetryUpdate(Object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            // there is apparently nothing in the telemetry data to tell us the session identifier
            // (meaning the session id that would be displayed in iRacing results); the session 
            // identifers in the telemetry seem be as follows:
            //   SessionNum      --> an index into the Sessions in the SessionInfo
            //   SessionUniqueId --> I've only seen the number 1 so far in an official practice
            // this means we can't know the sessionLogPath until it has been calculated by the
            // first session info update so can log no telemetry updates until that occurs; in
            // practice this seems to be fine
            if (record && sessionLogPath != null)
            {
                // NOTE: we only record fields which we've exposed in ITelemetryInfo for two reasons.
                // First, there is no way to simply get a copy of the whole binary record from iRSDKSharp,
                // so we'd have to loop across all the fields by name and read each one (we do a subset of
                // this of course in the solution below, but only on a smallish number of fields).
                // A second reason is simply to keep our session log file as small as possible.
                using (BinaryWriter w = AppendBinary(sessionLogPath))
                {
                    w.Write(2); // telemetry update record identifier
                    w.Write(e.TelemetryInfo.SessionFlags.Value.Value);
                    w.Write(e.TelemetryInfo.SessionNum.Value);
                    w.Write(e.TelemetryInfo.SessionUniqueID.Value);
                    w.Write(e.TelemetryInfo.SessionTimeRemain.Value);
                    w.Write(wrapper.GetTelemetryValue<int>("SessionLapsRemain").Value);
                }
            }

            telemetryUpdateHandlers.ForEach(
                h => h.Invoke(sender, new TelemetryUpdatedEventProxy(
                    new TelemetryInfoProxy(wrapper, e.TelemetryInfo))));
        }

        public void AddSessionInfoUpdateHandler(EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handler)
        {
            sessionInfoUpdateHandlers.Add(handler);
        }

        public void OnSessionInfoUpdate(Object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            if (record)
            {
                if (sessionLogPath == null)
                {
                    YamlQuery q = e.SessionInfo["WeekendInfo"]["SessionID"];
                    string sessionId = q.GetValue("default");
                    sessionLogPath = MakeSessionLogPath(sessionId);
                }
                using (BinaryWriter w = AppendBinary(sessionLogPath))
                {
                    w.Write(1); // session info update record identifer
                    w.Write(e.UpdateTime);
                    WriteUTF8(w, e.SessionInfo.Yaml);
                }
            }

            sessionInfoUpdateHandlers.ForEach(h => h.Invoke(sender, e));
        }

        private void WriteUTF8(BinaryWriter w, string s)
        {
            WriteByteArray(w, Encoding.UTF8.GetBytes(s));
        }

        private void WriteByteArray(BinaryWriter w, byte[] bytes)
        {
            w.Write(bytes.Length);
            w.Write(bytes);
        }

        private BinaryWriter AppendBinary(string path)
        {
            return new BinaryWriter(new FileStream(path, FileMode.Append, FileAccess.Write));
        }

        private string MakeSessionLogPath(string sessionId)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return documentsPath + "\\race-admin-session-" + sessionId + ".bin";
        }

        public void SetTelemetryUpdateFrequency(int updateFrequency)
        {
            wrapper.TelemetryUpdateFrequency = updateFrequency;
        }

        public void Start()
        {
            wrapper.Start();
        }

        public void Stop()
        {
            wrapper.Stop();
        }

        public ITelemetryValue<T> GetTelemetryValue<T>(string name)
        {
            return new TelemetryValueProxy<T>(wrapper.GetTelemetryValue<T>(name));
        }

    }
}
