using System;
using System.Collections.Generic;
using iRacingSdkWrapper;

namespace RaceAdmin
{
    /// <summary>
    /// ISdkWrapper allows us to inject test implementations of the iRacingSdkWrapper.
    /// </summary>
    public interface ISdkWrapper
    {
        void AddSessionInfoUpdateHandler(EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handler);

        void AddTelemetryUpdateHandler(EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> handler);

        void SetTelemetryUpdateFrequency(int updateFrequency);

        void Start();
        void Stop();
        bool IsLive();
        ITelemetryValue<T> GetTelemetryValue<T>(string name);
    }
}
