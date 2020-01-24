using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Target_NETCORE.DI;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Registration;
using Unity.RegistrationByConvention;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Target_NETCORE.DI.autofac;
using System.Configuration;
using Microsoft.Extensions.Options;
using CORE.common.infrastructure;
using CORE.common.Options;
using AutoMapper;
using Target_NETCORE.infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace WebApplication1
{
    public class Startup
    {

        public static log4net.ILog log;
        public IConfiguration _Configuration { get; }
        public Startup(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region MVC
            services.AddMvc()
                           .AddJsonOptions(
                     options =>
                     {
                         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                         options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
                         options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

                     }
                 );

            services.AddCors(o => o.AddPolicy("AllowAllPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.Configure<GzipCompressionProviderOptions>
       (options => options.Level = CompressionLevel.Fastest);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
            #endregion
            #region Log
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Error("Application Log started");
            services.AddSingleton<ILog>(log);
            #endregion 
            #region AutoFac
            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();

            List<Assembly> allAssemblies = new List<Assembly>();
            string basePath = AppDomain.CurrentDomain.RelativeSearchPath
           ?? AppDomain.CurrentDomain.BaseDirectory;
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
            foreach (string dll in Directory.GetFiles(basePath, "Target_NETCORE.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "CORE.BL.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "CORE.common.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));
            foreach (string dll in Directory.GetFiles(basePath, "CORE.Repository.dll"))
                allAssemblies.Add(Assembly.LoadFrom(dll));

            allAssemblies.ForEach(c => { log.Error(c.FullName); });
            log.Error(Directory.GetFiles(basePath, "CORE.BL.dll").Length);
            log.Error( basePath );
            //    containerBuilder.RegisterAssemblyTypes(allAssemblies.ToArray())
            //.Where(x => x.IsClass && x.IsPublic && x.GetInterfaces().Where(c => c.Name.Contains(x.Name) && c.Name.ToLower().StartsWith("i")).Any())
            //.As(t => t.GetInterfaces().FirstOrDefault(c => c.Name.Contains(t.Name) && c.Name.ToLower().StartsWith("i")));//.InstancePerDependency();



            containerBuilder.RegisterAssemblyTypes(allAssemblies.ToArray())
     .Where(x => x.IsClass && x.IsPublic)
     .As(t => t.GetInterfaces().Any(c => c.Name.Contains(t.Name) && c.Name.ToLower().StartsWith("i")) == false ? t : t.GetInterfaces().FirstOrDefault(c => c.Name.Contains(t.Name) && c.Name.ToLower().StartsWith("i")));//.InstancePerDependency();

            #endregion

            #region Options
            services.Configure<DBOptions>(_Configuration.GetSection(nameof(DBOptions)));
            services.Configure<EmailOptions>(_Configuration.GetSection(nameof(EmailOptions)));
            #endregion
            #region OTHERlAYERS

            CORE.BL.infrastructure.DIRegister.Register(services);
            CORE.BL.infrastructure.AutofacRegister.Register(containerBuilder);

            #endregion




            containerBuilder.Populate(services);
            var container = containerBuilder.Build();





            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseCors("AllowAllPolicy");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "API/{controller=Home}/{action=Index}/{id?}");
            });
            app.UseResponseCompression();
            Mapper.Initialize(c => AutomapperConf.Mapping(c));
        }
    }

}
