using CORE.DAL.DBContext;
using CORE.DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.infrastructure
{
    public static class DIRegister
    {

        public static void Register(IServiceCollection services)
        {
            //services.AddDbContext<MVCBaseDBContext>(options => 
            //options.UseSqlServer("data source=.;initial catalog=MVCBaseDB;user id=sa;password=P@ssw0rd;Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework"));
            services.AddSingleton<MVCBaseDBContext>();
            //var options = new DbContextOptionsBuilder<MVCBaseDBContext>()
            //              .Options;
            //services.AddSingleton<DbContext>(x => new MVCBaseDBContext(options, null));

        }

    }
}
