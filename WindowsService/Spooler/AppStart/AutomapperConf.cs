using AutoMapper;
using CORE.BL.Dto;
using CORE.BL.Dto.Menu;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Spooler.App_Start
{
    public static class AutomapperConf
    {
        public static IMapperConfigurationExpression Mapping(IMapperConfigurationExpression cfg)
        {

            cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(1));
            
            #region BL
            BL.infrastructure.AutomapperConf.Mapping(cfg);
            #endregion
         

            return cfg;
        }
        public static string Localize(string english, string arabic)
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("en"))
            {
                return english;
            }
            else
            {
                return arabic;
            }
        }
    }
}