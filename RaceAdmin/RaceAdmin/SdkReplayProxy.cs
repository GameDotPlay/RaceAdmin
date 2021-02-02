using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RaceAdmin
{
    class SdkReplayProxy : ISdkWrapper
    {
        private readonly BinaryReader reader;
        private readonly int session;
        private readonly List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers;
        private readonly List<EventHandler<ITelemetryUpdatedEvent>> telemetryUpdateHandlers;

        public SdkReplayProxy(BinaryReader reader, int session)
        {
            this.reader = reader;
            this.session = session;
            sessionInfoUpdateHandlers = new List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>>();
            telemetryUpdateHandlers = new List<EventHandler<ITelemetryUpdatedEvent>>();
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
            ReplayLoop loop = new ReplayLoop(reader, session, sessionInfoUpdateHandlers, telemetryUpdateHandlers);
            Thread t = new Thread(new ThreadStart(loop.Run))
            {
                Name = "ReplayLoop",
                IsBackground = true
            };
            t.Start();
        }

        public void Stop()
        {
            reader.Close(); // probably not threadsafe (well, not threadsafe but program is closing)
        }
    }

    public class ReplayLoop
    {
        private readonly BinaryReader reader;
        private readonly int session;
        private readonly List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers;
        private readonly List<EventHandler<ITelemetryUpdatedEvent>> telemetryUpdateHandlers;

        public ReplayLoop(BinaryReader reader, int session, List<EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs>> sessionInfoUpdateHandlers, List<EventHandler<ITelemetryUpdatedEvent>> telemetryUpdateHandlers)
        {
            this.reader = reader;
            this.session = session;
            this.sessionInfoUpdateHandlers = sessionInfoUpdateHandlers;
            this.telemetryUpdateHandlers = telemetryUpdateHandlers;
        }

        public void Run()
        {
            try
            {
                var lastUpdateTime = 0.0;
                var currentSession = 0;
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var sendEvents = session == -1 || session == currentSession;

                    int recordType = reader.ReadInt32();
                    switch (recordType)
                    {
                        case 1:
                            var e = DoSessionInfoUpdate(sendEvents);
                            if (e.UpdateTime < lastUpdateTime)
                            {
                                // this is needed because we do not currently record/playback 
                                // the telemetry updates which are the only way that the client
                                // can detect session transitions
                                currentSession++;
                                SendFakeTelemetryUpdate(currentSession);
                            }
                            lastUpdateTime = e.UpdateTime;
                            break;
                        default:
                            break;
                    }
                    if (sendEvents)
                    {
                        Thread.Sleep(50);
                    }
                }
                reader.Close();
            }
            catch (ObjectDisposedException)
            {
                // just ignore; reader closed by parent thread or program closing anyway
            }
        }

        private void SendFakeTelemetryUpdate(int currentSession)
        {
            var args = new FakeTelemetryUpdatedEvent(new FakeTelemetryInfo()
            {
                SessionFlags = new FakeTelemetryValue<SessionFlag>(new SessionFlag(0)),
                SessionNum = new FakeTelemetryValue<int>(currentSession),
                SessionUniqueID = new FakeTelemetryValue<int>(currentSession),
            });
            telemetryUpdateHandlers.ForEach(h => h.Invoke(this, args));
        }

        private SdkWrapper.SessionInfoUpdatedEventArgs DoSessionInfoUpdate(bool sendEvents)
        {
            var timestamp = reader.ReadDouble();
            var yaml = ReadUTF8(reader);
            var args = new SdkWrapper.SessionInfoUpdatedEventArgs(yaml, timestamp);

            if (sendEvents)
            {
                sessionInfoUpdateHandlers.ForEach(h => h.Invoke(this, args));
            }

            return args;
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
