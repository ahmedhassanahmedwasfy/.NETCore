using Common;
using Microsoft.Practices.Unity;
using Repository.Repositories; 
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
 
namespace Repository.infrastructure
{
    public static class UnityRegister
    {
        public static void Register(IUnityContainer container)
        {
           
        }
    }
}
