 
using DAL.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace DAL.infrastructure
{
    public static class UnityRegister
    {
        public static void Register(IUnityContainer  container)
        {
            container.RegisterType<DbContext, DBContext.MVCBaseDBContext>(new TransientLifetimeManager() );
     

        }
    }
}
