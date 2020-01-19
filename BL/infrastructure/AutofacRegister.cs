using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.infrastructure
{
  
        public static class AutofacRegister
        {
            public static ContainerBuilder container { get; set; }
            public static void Register(ContainerBuilder _container)
            {
                container = _container;
                DAL.infrastructure.AutofacRegister.Register(container);
            Repository.Pattern.infrastructure.AutofacRegister.Register(container);
     
            }
        }
  
}
