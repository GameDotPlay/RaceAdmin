using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SdkWrapperProxy(SdkWrapper wrapper)
        {
            this.wrapper = wrapper;
        }
        public void AddTelemetryUpdateHandler(EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> handler)
        {
            wrapper.TelemetryUpdated += handler;
        }

        public void AddSessionInfoUpdateHandler(EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> handler)
        {
            wrapper.SessionInfoUpdated += handler;
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

        public TelemetryValue<T> GetTelemetryValue<T>(string name)
        {
            return wrapper.GetTelemetryValue<T>(name);
        }

    }
}
