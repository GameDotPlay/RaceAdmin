using iRacingSdkWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RaceAdmin
{
    class SdkReplayProxy : ISdkWrapper
    {
        private BinaryReader reader;
        private List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers;
        private List<EventHandler<ITelemetryUpdatedEvent>> telemetryUpdateHandlers;

        public SdkReplayProxy(BinaryReader reader)
        {
            this.reader = reader;
            this.sessionInfoUpdateHandlers = new List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>>();
            this.telemetryUpdateHandlers = new List<EventHandler<ITelemetryUpdatedEvent>>();
        }

        public bool IsLive()
        {
            return false;
        }

        public void AddSessionInfoUpdateHandler(EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handler)
        {
            sessionInfoUpdateHandlers.Add(handler);
        }

        public void AddTelemetryUpdateHandler(EventHandler<ITelemetryUpdatedEvent> handler)
        {
            telemetryUpdateHandlers.Add(handler);
        }

        public ITelemetryValue<T> GetTelemetryValue<T>(string name)
        {
            throw new NotImplementedException();
        }

        public void SetTelemetryUpdateFrequency(int updateFrequency)
        {
            // ignored for now
        }

        public void Start()
        {
            ReplayLoop loop = new ReplayLoop(reader, sessionInfoUpdateHandlers);
            Thread t = new Thread(new ThreadStart(loop.ThreadProc));
            t.IsBackground = true;
            t.Start();
        }

        public void Stop()
        {
            reader.Close(); // probably not threadsafe (well, not threadsafe but program is closing)
        }
    }

    public class ReplayLoop
    {
        private BinaryReader reader;
        private List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers;

        public ReplayLoop(BinaryReader reader, List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers)
        {
            this.reader = reader;
            this.sessionInfoUpdateHandlers = sessionInfoUpdateHandlers;
        }

        public void ThreadProc()
        {
            try
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int recordType = reader.ReadInt32();
                    switch (recordType)
                    {
                        case 1:
                            DoSessionInfoUpdate();
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(50);
                }
                reader.Close();
            }
            catch (ObjectDisposedException)
            {
                // just ignore; reader closed by parent thread or program closing anyway
            }
        }

        private void DoSessionInfoUpdate()
        {
            var timestamp = reader.ReadDouble();
            var yaml = ReadUTF8(reader);
            var args = new SdkWrapper.SessionInfoUpdatedEventArgs(yaml, timestamp);
            foreach (var handler in sessionInfoUpdateHandlers)
            {
                handler.Invoke(this, args);
            }
        }

        private string ReadUTF8(BinaryReader reader)
        {
            byte[] data = ReadByteArray(reader);
            return System.Text.Encoding.UTF8.GetString(data);
        }

        private byte[] ReadByteArray(BinaryReader reader)
        {
            int length = reader.ReadInt32();
            return reader.ReadBytes(length);
        }
    }
}
