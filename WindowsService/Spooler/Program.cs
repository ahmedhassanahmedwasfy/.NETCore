using AutoMapper;
using Spooler.App_Start;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace Spooler
{
    static class Program
    {
        static ILog _log;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {

                log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Spooler.exe.config"));
                Mapper.Initialize(c => AutomapperConf.Mapping(c));
                UnityConfiguration.ConfigureIoCContainer();
                var _container = UnityConfiguration.container;
                _log = _container.Resolve<ILog>();
                _log.Info("Started");
#if DEBUG
                new MainClss();
                Thread.Sleep(Timeout.Infinite);

#else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new MainClss()

                };
                ServiceBase.Run(ServicesToRun);
#endif
            }
            catch (Exception ex)
            { 
                _log.Error(ex);
            }
        }
    }
}
