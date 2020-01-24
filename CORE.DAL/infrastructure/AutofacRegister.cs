using Autofac;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.infrastructure
{

    public static class AutofacRegister
    {
        public static ContainerBuilder container { get; set; }
        public static void Register(ContainerBuilder _container)
        {
            container = _container;
            container.RegisterType<DBContext.MVCBaseDBContext>().As<DbContext>().InstancePerDependency();
          
        }
    }
}
