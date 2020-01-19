using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.infrastructure
{
   public static class DIRegister
    {
        public static void Register(IServiceCollection services)
        {
            DAL.infrastructure.DIRegister.Register(services);
        }
    }
}
