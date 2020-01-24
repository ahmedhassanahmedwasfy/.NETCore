
using AutoMapper;
using CORE.BL.Dto;

using CORE.BL.Services;
using CORE.DAL.Models;
using CORE.DAL.Models.Menu;
using CORE.DAL.Models.UserManagement;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.infrastructure
{
    public static class AutomapperConf
    {
        public static IMapperConfigurationExpression Mapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
            cfg.CreateMap<DateTime, string>().ConvertUsing<DateTimeToStringConverter>();

            cfg.CreateMap<tbl_User, dto_User>()
        .ForMember(x => x.Privilliges, opt => opt.MapFrom(c => c.tbl_Privilligetbl_User.Select(x => x.Privillige)))
        .ForMember(x => x.Groups, opt => opt.MapFrom(c => c.tbl_Grouptbl_User.Select(x => x.Group)));
            cfg.CreateMap<dto_User, tbl_User>()
       .ForMember(x => x.tbl_Privilligetbl_User, opt => opt.MapFrom(c => c.Privilliges.Select(x => new tbl_Privilligetbl_User() { tbl_Privillige_ID = x.ID, tbl_User_ID = c.ID })))
       .ForMember(x => x.tbl_Grouptbl_User, opt => opt.MapFrom(c => c.Groups.Select(x => new tbl_Grouptbl_User() { tbl_Group_ID = x.ID, tbl_User_ID = c.ID })))
      ;


            cfg.CreateMap<tbl_Group, dto_Group>()
        .ForMember(x => x.Privilliges, opt => opt.MapFrom(c => c.tbl_Privilligetbl_Group.Select(x => x.Privillige)))
        .ForMember(x => x.Users, opt => opt.MapFrom(c => c.tbl_Grouptbl_User.Select(x => x.User)))
        .ReverseMap();
            cfg.CreateMap<dto_Group, tbl_Group>()
 .ForMember(x => x.tbl_Privilligetbl_Group, opt => opt.MapFrom(c => c.Privilliges.Select(x => new tbl_Privilligetbl_Group() { tbl_Privillige_ID = x.ID, tbl_Group_ID = c.ID })))
 .ForMember(x => x.tbl_Grouptbl_User, opt => opt.MapFrom(c => c.Users.Select(x => new tbl_Grouptbl_User() { tbl_User_ID = x.ID, tbl_Group_ID = c.ID })))
  ;

            cfg.CreateMap<tbl_Privillige, dto_Privillige>()
        .ForMember(x => x.Users, opt => opt.MapFrom(c => c.tbl_Privilligetbl_User.Select(x => x.User)))
        .ForMember(x => x.Groups, opt => opt.MapFrom(c => c.tbl_Privilligetbl_Group.Select(x => x.Group)))
        .ReverseMap();
            cfg.CreateMap<dto_Privillige, tbl_Privillige>()
.ForMember(x => x.tbl_Privilligetbl_Group, opt => opt.MapFrom(c => c.Groups.Select(x => new tbl_Privilligetbl_Group() { tbl_Privillige_ID = c.ID, tbl_Group_ID = x.ID })))
.ForMember(x => x.tbl_Privilligetbl_User, opt => opt.MapFrom(c => c.Users.Select(x => new tbl_Privilligetbl_User() { tbl_Privillige_ID  = c.ID, tbl_User_ID = x.ID })))
 ;




            //max depth 3 for menu
            //cfg.CreateMap<Dto.Menu.dto_Menu, tbl_Menu>().ReverseMap().MaxDepth(3);

            //cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(1));
            //cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(3));
            //cfg.CreateMap<Dto.dto_User, tbl_User>().ReverseMap().MaxDepth(3);
            //cfg.CreateMap<Dto.dto_Privillige, tbl_Privillige>().ReverseMap().MaxDepth(3);
            //cfg.CreateMap<Dto.dto_Printer, tbl_Printer>().ReverseMap().MaxDepth(3);
            //cfg.CreateMap<Dto.dto_PrintersGroup, tbl_PrintersGroup>().ReverseMap().MaxDepth(3);

            //    cfg.CreateMap<dto_Layout, tbl_Layout>()
            //.ForMember(x => x.Category, opt => opt.MapFrom(c => c.Category.NameEn))
            //.ForMember(x => x.Type, opt => opt.MapFrom(c => c.Type.NameEn));
            //   cfg.CreateMap<tbl_Layout,dto_Layout  >()
            //.ForMember(x => x.Category, opt => opt.MapFrom(c => new dto_Category() { NameEn = c.Category }) )
            //.ForMember(x => x.Type, opt => opt.MapFrom(c => new dto_Type() { NameEn = c.Type }) ) 
            //.ReverseMap();



            //.ForMember(x => x.ExpiryDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.ExpiryDate) ? DateTime.ParseExact(c.ExpiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //.ForMember(x => x.RequestDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.RequestDate) ? DateTime.ParseExact(c.RequestDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //.ForMember(x => x.StatusDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.StatusDate) ? DateTime.ParseExact(c.StatusDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))



            //    cfg.CreateMap<dto_PrintingQueue, dto_CardData>()
            //     .ForMember(x => x.ExpiryDate, opt => opt.MapFrom(c => c.ExpiryDate.ToString("dd/MM/yyyy")))  
            //.ReverseMap();



            //.ForMember(x => x.DateOfBirth, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.DateOfBirth)?  DateTime.ParseExact(c.DateOfBirth, "MM/dd/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //.ForMember(x => x.ExpiryDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.ExpiryDate) ? DateTime.ParseExact(c.ExpiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //.ForMember(x => x.RequestDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.RequestDate) ? DateTime.ParseExact(c.RequestDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //.ForMember(x => x.StatusDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.StatusDate) ? DateTime.ParseExact(c.StatusDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))





            //.ForMember(x => x.DateOfBirth, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.DateOfBirth) ? DateTime.ParseExact(c.DateOfBirth, "MM/dd/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //   .ForMember(x => x.ExpiryDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.ExpiryDate) ? DateTime.ParseExact(c.ExpiryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //   .ForMember(x => x.RequestDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.RequestDate) ? DateTime.ParseExact(c.RequestDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))
            //   .ForMember(x => x.StatusDate, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.StatusDate) ? DateTime.ParseExact(c.StatusDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue))



            return cfg;
        }
        public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
        {


            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                object objDateTime = source;
                DateTime dateTime;

                if (objDateTime == null)
                {
                    return default(DateTime);
                }

                if (DateTime.TryParseExact(objDateTime.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return dateTime;
                }
                else if (DateTime.TryParseExact(objDateTime.ToString(), "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return dateTime;
                }
                else if (DateTime.TryParse(objDateTime.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    return dateTime;
                }
                return default(DateTime);
            }
        }
    }
}
