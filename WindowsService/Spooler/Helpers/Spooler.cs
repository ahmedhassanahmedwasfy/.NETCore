using BL.Configuration;
using BL.Dto;
using BL.Services;
using Common.Constants;
using Common.Enums;
using Spooler.App_Start;
using log4net; 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity; 

namespace Spooler.Helpers
{
    public class cls_Spooler
    {
        ILog _log;
        int _sleeptime = 1000;
        public int _SleepTime_Vostok
        {
            get
            {
                return _configurations.SleepTime_Vostok;
            }
        }

        IAppSettings _configurations;
        
        dtoHelper _dto_Helper; 
     
        public cls_Spooler( ILog log, IAppSettings appSettings )
        {
            _log = log;
            _configurations = appSettings;
            _sleeptime = appSettings.Spooler_SleepTime; 
          
            _dto_Helper = new dtoHelper();
         
        }
        public void CP500_Process(IUnityContainer container)
        {
            #region Printer 
           
            #endregion 
        }
        public async Task HangedNowPriningQueueTask(CancellationToken token)
        {
            var _container = UnityConfiguration.container;
            while (true)
            {
                try
                {
                    
                   
                }
                catch (Exception e)
                {
                    _log.Error(e);
                }
                await Task.Delay(_sleeptime, token);
            }
        }
        public async Task SendFailedVostok(CancellationToken token)
        {
            var _container = UnityConfiguration.container;
            while (true)
            {
                try
                {
                  

                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    _log.Error(e);
                }
                await Task.Delay(_SleepTime_Vostok, token);
            }
        }
    }
}