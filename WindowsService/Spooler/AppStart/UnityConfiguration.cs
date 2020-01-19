using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using BL;
using Unity;
using System.Reflection;
using Unity.RegistrationByConvention;
using Unity.Lifetime;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.InterceptionBehaviors;
using System.Collections;
using Unity.Interception.ContainerIntegration;
using Unity.Attributes;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Registration;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Common;
using System.IO;
using Newtonsoft.Json;
using Spooler.Configuration;
using BL.Configuration; 

namespace Spooler.App_Start
{

    public static class UnityConfiguration
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IUnityContainer container;
        public static void ConfigureIoCContainer()
        {

            container = new UnityContainer();
            container.AddNewExtension<Interception>();

            RegisterTypes(container);

        }

        private static void RegisterTypes(IUnityContainer container)
        {

            string basePath = AppDomain.CurrentDomain.RelativeSearchPath
             ?? AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> allAssemblies = new List<Assembly>();
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
            foreach (string dll in Directory.GetFiles(basePath, "Spooler.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "BL.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "Common.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "Urf.Repository.Pattern.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "DAL.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "Printing_CP500.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "VOSTOKDataSource.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));

            container.RegisterInstance<ILog>(log, new ContainerControlledLifetimeManager());
            container.RegisterTypes(
           AllClasses.FromAssembliesInBasePath().WithMatchingInterface() // for all assemblies
           //AllClasses.FromLoadedAssemblies().WithMatchingInterface() // for all assemblies
           //AllClasses.FromAssemblies(allAssemblies).WithMatchingInterface() // for specified only
            , WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Transient,

                            c => new InjectionMember[]
                {
                       new  Interceptor<InterfaceInterceptor>()
                  ,
                    new InterceptionBehavior<ProfilingInterceptionBehavior>()
                }
                //null 
                , true);


            //container.RegisterType<IVostok_Helper, Vostok_Helper>(new TransientLifetimeManager());
            //container.RegisterType<IAppSettings, AppSettings>(new TransientLifetimeManager()); 
            //container.RegisterType<Itest, test>(new TransientLifetimeManager(), new Interceptor<InterfaceInterceptor>(),
            //new InterceptionBehavior<ProfilingInterceptionBehavior>());

            common.infrastructure.UnityRegister.Register(container);
            BL.infrastructure.UnityRegister.Register(container);
            //Itest t = container.Resolve<Itest>();
            //t.write();
        }
    }

    public class ProfilingInterceptionBehavior : IInterceptionBehavior
    {
        [Dependency]
        public ILog Log { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input,
            GetNextInterceptionBehaviorDelegate getNext)
        {
            var startTime = DateTime.Now;
            var result = getNext()(input, getNext);

            //if (!input.MethodBase.Name.ToLower().Contains("debug"))

            //This behavior will record the start and stop time
            //of a method and will log the method name and elapsed time.
            //Get the current time.

            //Log the start time of the method.
            //This could be ommitted if you just want to see the response times of a method.
            //WriteLog(String.Format(
            //  "Invoking method {0} at {1}",
            //  input.MethodBase, startTime.ToLongTimeString()));

    //        string Params = "";
    //        foreach (var item in input.Arguments)
    //        {
    //            if (item != null)
    //            {
    //                string Itemstr = JsonConvert.SerializeObject(item,
    //Formatting.None,
    //new JsonSerializerSettings()
    //{
    //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    //});
    //                Params += Itemstr + " , ";

    //            }
    //            else
    //            {
    //                Params += " null " + " , ";
    //            }
    //        }
    //        WriteLog(String.Format(
    //      "Method {0} Takes Arguments {1} ",
    //      input.MethodBase, Params));

            // Invoke the next behavior in the chain.

            //Calculate the elapsed time.
            var endTime = DateTime.Now;
            var timeSpan = endTime - startTime;


            //The following will log the method name and elapsed time.
            if (result.Exception != null)
            {

                //Method threw an exception.
                WriteExecptionLog(String.Format(
                  "Method {0} threw exception {1} at {2}.  Elapsed Time: {3} ms",
                  input.MethodBase, result.Exception.Message,
                  endTime.ToLongTimeString(),
                  timeSpan.TotalMilliseconds));
            }
            else
            {
                //Method completed normally.
                //WriteLog(String.Format(
                //  "Method {0} returned {1} at {2}.  Elapsed Time: {3} ms",
                //  input.MethodBase, result.ReturnValue,
                //  endTime.ToLongTimeString(),
                //  timeSpan.TotalMilliseconds));
            }
            //$"{Environment.NewLine}Method {0} returned {1} at {2}.  Elapsed Time: {3} ms"

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
            if (Log != null)
            {
                //if (!message.ToLower().Contains("Method debug"))
                {
                    Log.DebugFormat("Profiler: {0}", message);
                }
            }
        }
        private void WriteExecptionLog(string message)
        {
            if (Log != null)
            {
                //if (!message.ToLower().Contains("Method debug"))
                {
                    Log.ErrorFormat("Profiler: {0}", message);
                }
            }
        }
    }
    public static class TypeFiltres
    {
        public static IEnumerable<Type> WithMatchingInterface(this IEnumerable<Type> types)
        {
            return types.Where(type =>
                type.GetTypeInfo().GetInterface("I" + type.Name) != null);
        }
    }
}