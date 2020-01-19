
using BL.Services;
using Common;
using DAL.Models;
using Microsoft.Practices.Unity;
using Repository.Repositories;
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

namespace BL.infrastructure
{
    public static class UnityRegister
    {
        public static IUnityContainer container { get; set; }
        public static void Register(IUnityContainer _container)
        {
            container = _container;
            DAL.infrastructure.UnityRegister.Register(container); 
            Repository.infrastructure.UnityRegister.Register(container); 
        }
    }
}
