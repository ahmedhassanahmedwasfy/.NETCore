using Autofac;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Target_NETCORE.DI.autofac
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CharacterRepository>().As<ICharacterRepository>();
        }
    }
}
