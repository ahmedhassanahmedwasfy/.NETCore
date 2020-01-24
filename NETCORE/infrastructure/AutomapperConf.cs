using AutoMapper;
using CORE.BL.Dto;
using CORE.BL.Dto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Target_NETCORE.Models.UserManagement;
using Target_NETCORE.Models.ViewModels.Menu;

namespace Target_NETCORE.infrastructure
{
    public static class AutomapperConf
    {
        public static IMapperConfigurationExpression Mapping(IMapperConfigurationExpression cfg)
        {
            #region UserManagementView
            cfg.CreateMap<dto_Privillige, PrivilligeCheckViewModel>()
           .ForMember(x => x.IsChecked, opt => opt.UseValue<bool>(false)).ReverseMap();
            cfg.CreateMap<dto_Group, GroupCheckViewModel>()
           .ForMember(x => x.IsChecked, opt => opt.UseValue<bool>(false)).ReverseMap();
            #endregion
            #region Menu
            cfg.CreateMap<dto_Menu, MenuItemViewModel>()
            .ForMember(x => x.title, opt => opt.MapFrom(src => Localize(src.NameEn, src.NameAr)))
            //.ForMember(x => x.title, opt => opt.MapFrom(src=>src.EnglishName))
            //.ForMember(x => x.icon, opt => opt.MapFrom(src => src.icon))
            //.ForMember(x => x.link, opt => opt.MapFrom(src=>src.link))
            ////.ForMember(x => x.children, opt => opt.Ignore())

            ////.ForMember(x => x.children, opt => opt.Ignore())
            .ReverseMap();


            #endregion
            #region BL
            CORE.BL.infrastructure.AutomapperConf.Mapping(cfg);
            #endregion
            #region Reports

            #endregion
            //cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(3));
            cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.PreserveReferences());

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