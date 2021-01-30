using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iRacingSdkWrapper;

namespace RaceAdmin
{
    /// <summary>
    /// Provides a passthrough proxy implementation of the ISdkWrapper interface which 
    /// simply delegates to the SdkWrapper provided in the constructor.
    /// </summary>
    public class SdkWrapperProxy : ISdkWrapper
    {
        private readonly SdkWrapper wrapper;
        private bool record;

        // TODO: these need to be lists so client code can add more than one of each type
        private EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handleSessionInfoUpdate;
        private EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> handleTelemetryUpdate;

        public SdkWrapperProxy(SdkWrapper wrapper)
        {
            this.wrapper = wrapper;
            this.record = false;

            wrapper.TelemetryUpdated += OnTelemetryUpdate;
            wrapper.SessionInfoUpdated += OnSessionInfoUpdate;
        }

        public void AddTelemetryUpdateHandler(EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> handler)
        {
            this.handleTelemetryUpdate = handler;
        }

        private void OnTelemetryUpdate(Object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
        {
            if (record)
            {
                // TODO: consider implementing this...it's a bit complicated and not absolutely
                // necessary for what is needed to be recorded in order to debug the incident
                // counting bugs related to team driving
            }

            handleTelemetryUpdate?.Invoke(sender, e);
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

        public void Start(bool record)
        {
            this.record = record;
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
