using iRacingSdkWrapper;
using System;
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

        // TODO: these need to be lists so client code can add more than one of each type
        private EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handleSessionInfoUpdate;
        private EventHandler<ITelemetryUpdatedEvent> handleTelemetryUpdate;

        public SdkWrapperProxy(SdkWrapper wrapper, bool record)
        {
            this.wrapper = wrapper;
            this.record = record;

            wrapper.TelemetryUpdated += OnTelemetryUpdate;
            wrapper.SessionInfoUpdated += OnSessionInfoUpdate;
        }

        public bool IsLive()
        {
            return true;
        }

        public void AddTelemetryUpdateHandler(EventHandler<ITelemetryUpdatedEvent> handler)
        {
            this.handleTelemetryUpdate = handler;
        }

        private void OnTelemetryUpdate(Object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            if (record)
            {
                // TODO: this is needed in order to know which session (practice, qualify, race)
                // as well as to detect any flags displayed (green, yellow, etc.)
            }

            handleTelemetryUpdate?.Invoke(sender, new TelemetryUpdatedEventProxy(new TelemetryInfoProxy(e.TelemetryInfo)));
        }

        public void AddSessionInfoUpdateHandler(EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handler)
        {
            this.handleSessionInfoUpdate = handler;
        }

        private void OnSessionInfoUpdate(Object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            if (record)
            {
                YamlQuery q = e.SessionInfo["WeekendInfo"]["SessionID"];
                string sessionId = q.GetValue("default");
                using (BinaryWriter w = AppendBinary(MakeSessionLogPath(sessionId)))
                {
                    w.Write(1); // session info update record identifer
                    w.Write(e.UpdateTime);
                    WriteUTF8(w, e.SessionInfo.Yaml);
                }
            }

            handleSessionInfoUpdate?.Invoke(sender, e);
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
