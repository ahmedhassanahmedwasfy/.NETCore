using BL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Target_NETCORE.Configuration
{
    public class AppSettings : IAppSettings
    {
        public string location  { get; set; }

        public int ServiceReceiptsFrom { get; set; }

        public string ServiceRequestFrom { get; set; }

        public string SiraServiceClientIp { get; set; }

        public string SiraServiceMacAddress { get; set; }

        public string SiraServicePassword { get; set; }

        public string SiraServiceUserName { get; set; }

        public string ADDomain { get; set; }

        public int Spooler_SleepTime { get; set; }

        public int Dashboard_SleepTime { get; set; }

        public int NowPrintingHangTime { get; set; }

        public int SleepTime_Vostok { get; set; }

        public string GetValue(string key)
        {
            throw new NotImplementedException();
        }
    }
}
