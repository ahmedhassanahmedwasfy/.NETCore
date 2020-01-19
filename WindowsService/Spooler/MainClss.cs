using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using log4net;
using Unity;
using Spooler.App_Start;
using System.IO;
using BL.Services;
using System.Threading.Tasks;
using System;
using BL.Dto;
using System.Collections.Generic;
using AutoMapper;
using Spooler.Configuration;
using Repository.Repositories;
using BL.Services.Settings; 
using System.Linq;
using BL.Configuration;
using Spooler.Helpers;

namespace Spooler
{
    public partial class MainClss : ServiceBase
    {
        #region Fileds
        private ILog _log;
        private IUnityContainer _container;
        private Task _proccessHangedNowPriningQueueTask;
        private Task _proccessSentFailedVostok;
        private CancellationTokenSource _cancellationTokenSource;
        #endregion
        #region Constructor
        public MainClss()
        {
            try
            {
                #region AppStart
                InitializeComponent();

                _container = UnityConfiguration.container;
                _log = _container.Resolve<ILog>();
                #endregion
#if DEBUG
                OnStart(null);
#else
#endif
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }

        }
        #endregion


        protected override void OnStart(string[] args)
        {
            _log.Info("Method OnStart");
            try
            {
                cls_Spooler spooler = _container.Resolve<cls_Spooler>();
                //tst.VOSTOK_Process();
                //tst.Layout_Process();
                spooler.CP500_Process(_container);
                _cancellationTokenSource = new CancellationTokenSource();
#if DEBUG
                _proccessHangedNowPriningQueueTask = Task.Run(() => spooler.HangedNowPriningQueueTask(_cancellationTokenSource.Token));
                _proccessSentFailedVostok = Task.Run(() => spooler.SendFailedVostok(_cancellationTokenSource.Token));
#else
                _proccessHangedNowPriningQueueTask = Task.Run(() => spooler.HangedNowPriningQueueTask(_cancellationTokenSource.Token));
                _proccessSentFailedVostok = Task.Run(() => spooler.SendFailedVostok(_cancellationTokenSource.Token));
#endif
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        protected override void OnStop()
        {
            _cancellationTokenSource.Cancel();
            try
            {
                _proccessHangedNowPriningQueueTask.Wait();
                _proccessSentFailedVostok.Wait();
            }
            catch (Exception e)
            {
                _log.Error("OnStop _proccessQueueTask.Wait", e);
            }
            _log.Info("Method OnStop");
        }

    }
}
