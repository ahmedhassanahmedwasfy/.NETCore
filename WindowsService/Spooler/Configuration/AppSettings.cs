using CORE.BL.Configuration;
using CORE.BL.Services.Settings;
using log4net;
using CORE.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spooler.Configuration
{
    public class AppSettings : IAppSettings
    {
        ILog _log;
        IService_Settings _repositorySetting;
        public AppSettings(ILog log, IService_Settings repositorySetting)
        {
            _log = log;
            _repositorySetting = repositorySetting;
        }

        #region VOSTOK 
        public string location => ConfigurationManager.AppSettings["location"];
        public int ServiceReceiptsFrom
        {
            get
            {
                int retval = 1;
                int.TryParse(ConfigurationManager.AppSettings["ServiceReceiptsFrom"], out retval);
                return retval * -1;
            }
        }
        public string SiraServiceUserName => ConfigurationManager.AppSettings["SIRAServiceUserName"];
        public string SiraServicePassword => ConfigurationManager.AppSettings["SIRAServicePassword"];
        public string SiraServiceClientIp => ConfigurationManager.AppSettings["SIRAServiceClientIP"];
        public string SiraServiceMacAddress => ConfigurationManager.AppSettings["SIRAServiceMACAddress"];
        public string ServiceRequestFrom => ConfigurationManager.AppSettings["ServiceRequestFrom"];
        #endregion
        #region General
        public string ADDomain { get { return GetValue("Active_Directory_Domain"); } }
        //public bool IsEncode { get { return Convert.ToBoolean( GetValue("Is_Encode")); } } 
        public int SleepTime_Vostok
        {
            get
            {
                try
                {
                    string Value = GetValue("SleepTime_Vostok");
                    if (string.IsNullOrEmpty(Value))
                    {
                        return 120000;
                    }
                    else
                    {
                        return 1000*int.Parse(Value);
                    }
                }
                catch (Exception ex)
                {
                    return 120000;
                }
            }
        }
        #endregion
        #region Development
        public int Spooler_SleepTime
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Spooler_SleepTime"]);
            }
        }
        public int Dashboard_SleepTime
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Dashboard_SleepTime"]);
            }
        }
        public int NowPrintingHangTime
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["NowPrintingHangTime"]);

                }
                catch (Exception ex)
                {
                    return 180;
                }
            }
        }

        #endregion
        public string GetValue(string key)
        {
            try
            {
                var sett = _repositorySetting.GetValue(key);
                if (sett != null)
                {
                    return sett.Conf_Value;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }

            return null;
        }
    }
}
