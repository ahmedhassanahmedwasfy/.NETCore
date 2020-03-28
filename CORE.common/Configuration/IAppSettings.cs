using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.Configuration
{
    public interface IAppSettings
    {
        #region VOSTOK
        string location { get; }
        int ServiceReceiptsFrom { get; }
        string ServiceRequestFrom { get; }
        string SiraServiceClientIp { get; }
        string SiraServiceMacAddress { get; }
        string SiraServicePassword { get; }
        string SiraServiceUserName { get; }

        #endregion
        #region General
        string ADDomain { get; }
        //bool IsEncode { get; }
        #endregion
        #region Development
        int Spooler_SleepTime { get; }
        int Dashboard_SleepTime { get; }
        int NowPrintingHangTime { get; }
        int SleepTime_Vostok { get; }

        #endregion
        string GetValue(string key);
    }

}
