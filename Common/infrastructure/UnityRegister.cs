
using Common;
using Microsoft.Practices.Unity; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Registration;
using Unity.RegistrationByConvention;

namespace common.infrastructure
{
    public static class UnityRegister
    {
        public static void Register(IUnityContainer container)
        {
            //container.RegisterTypes(AllClasses.FromAssemblies(), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Transient,
            //   //null

            //    c => new InjectionMember[]
            //  {
            //        //new Interceptor<TransparentProxyInterceptor>() 
            //        //,
            //          new Interceptor<VirtualMethodInterceptor  >()
            //        ,
            //        new InterceptionBehavior<ProfilingInterceptionBehavior>()
            //  }

            //  , true);
            ////Container.RegisterType<ICustomerService, CustomerService>();
            ////container.RegisterType<IRepositoryAsync<Customer>, RepositoryAsync<Customer>>();



        }
    }
}
