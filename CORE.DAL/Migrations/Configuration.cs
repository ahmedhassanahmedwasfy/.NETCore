namespace CORE.DAL.Migrations
{
    using CORE.DAL.Models.Menu;
    using CORE.DAL.Models.UserManagement;
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System.Linq;
    using CORE.common;
    using CORE.DAL.Models;
    using System.IO;
    using Microsoft.Extensions.Options;
    using CORE.DAL.DBContext;
    using static System.Net.WebRequestMethods;
    using CORE.common.Helpers;
    using CORE.common.infrastructure;

    public static class Configuration
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();

            //context.Privilliges.RemoveRange(context.Privilliges.ToList());
            //context.Menus.RemoveRange(context.Menus.ToList());
            //context.SaveChanges();
            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [tbl_Privillige] ON");
            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [tbl_Menu] ON");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [tbl_Privillige]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [tbl_Menu]");
            //DBCC CHECKIDENT('tbl_Privillige',RESEED, 0) 

            #region Seed 
            #region UserTypes
            tbl_UserType ut1 = new tbl_UserType()
            {
                NameAr = "مريض",
                NameEn = "Patient"
            };
            tbl_UserType ut2 = new tbl_UserType()
            {
                NameAr = "طبيب",
                NameEn = "Doctor"
            };
            tbl_UserType ut3 = new tbl_UserType()
            {
                NameAr = "ادارة النظام",
                NameEn = "Administrator"
            };
            fillbase(ut1);
            fillbase(ut2);
            fillbase(ut3);
            modelBuilder.Entity<tbl_UserType>().HasData(ut1, ut2, ut3);

            #endregion
            #region Privilliges
            tbl_Privillige Page_administration = new tbl_Privillige()
            {

                Key = common.Enums.Enum_Privilliges.Page_administration.ToString(),
                NameAr = common.Enums.Enum_Privilliges.Page_administration.ToString(),
                NameEn = common.Enums.Enum_Privilliges.Page_administration.ToString()
            };
            tbl_Privillige Page_Groups = new tbl_Privillige()
            {
                Key = common.Enums.Enum_Privilliges.Page_Groups.ToString(),
                NameAr = common.Enums.Enum_Privilliges.Page_Groups.ToString(),
                NameEn = common.Enums.Enum_Privilliges.Page_Groups.ToString()
            };
            tbl_Privillige Page_Groups_Add = new tbl_Privillige()
            {
                Key = common.Enums.Enum_Privilliges.Page_Groups_Add.ToString(),
                NameAr = common.Enums.Enum_Privilliges.Page_Groups_Add.ToString(),
                NameEn = common.Enums.Enum_Privilliges.Page_Groups_Add.ToString()
            };
            tbl_Privillige Page_Users = new tbl_Privillige()
            {
                Key = common.Enums.Enum_Privilliges.Page_Users.ToString(),
                NameAr = common.Enums.Enum_Privilliges.Page_Users.ToString(),
                NameEn = common.Enums.Enum_Privilliges.Page_Users.ToString()
            };
            tbl_Privillige Page_Users_Add = new tbl_Privillige()
            {
                Key = common.Enums.Enum_Privilliges.Page_Users_Add.ToString(),
                NameAr = common.Enums.Enum_Privilliges.Page_Users_Add.ToString(),
                NameEn = common.Enums.Enum_Privilliges.Page_Users_Add.ToString()
            };

            fillbase(Page_Groups);
            fillbase(Page_Groups_Add);
            fillbase(Page_Users);
            fillbase(Page_Users_Add);
            fillbase(Page_administration);
            modelBuilder.Entity<tbl_Privillige>().HasData(Page_Groups, Page_Groups_Add, Page_Users, Page_Users_Add, Page_administration);

            #endregion
            #region Privilliges_Groups
            tbl_Group AdminGroup = new tbl_Group()
            {

                NameAr = common.Enums.Enum_PrivilligesGroup.AdminGroup.ToString(),
                NameEn = common.Enums.Enum_PrivilligesGroup.AdminGroup.ToString()
            };
            tbl_Group DoctorGroup = new tbl_Group()
            {

                NameAr = common.Enums.Enum_PrivilligesGroup.DoctorGroup.ToString(),
                NameEn = common.Enums.Enum_PrivilligesGroup.DoctorGroup.ToString()
            };
            tbl_Group PatientGroup = new tbl_Group()
            {

                NameAr = common.Enums.Enum_PrivilligesGroup.PatientGroup.ToString(),
                NameEn = common.Enums.Enum_PrivilligesGroup.PatientGroup.ToString()
            };
            fillbase(AdminGroup);
            fillbase(DoctorGroup);
            fillbase(PatientGroup);
            modelBuilder.Entity<tbl_Group>().HasData(AdminGroup, DoctorGroup, PatientGroup);

            #endregion 
            #region Menu

            List<tbl_Menu> Menus = new List<tbl_Menu>();


            #region Security

            //tbl_Menu Menu_Security_Privilliges = new tbl_Menu()
            //{

            //    NameAr = "Privilliges",
            //    icon = "ion-card",
            //    NameEn = "Privilliges",
            //    link = "/pages/Security/privilliges/Index",

            //};
            tbl_Menu Menu_Security = new tbl_Menu()
            {

                ParentID = null,
                NameAr = " الادارة",
                NameEn = "administration",
                icon = "ion-settings",
                link = "",
                PrivilligeID = Page_administration.ID,
                //Children = new List<tbl_Menu>()
                //{
                //    Menu_Security_Users,
                //    Menu_Security_Groups,
                //}
            };
            fillbase(Menu_Security);
            tbl_Menu Menu_Security_Groups = new tbl_Menu()
            {
                ID = Guid.NewGuid(),
                ParentID = Menu_Security.ID,
                NameAr = "المجموعات",
                icon = "fa fa-object-group",
                NameEn = "groups",
                link = "/pages/administration/groups",
            };
            fillbase(Menu_Security_Groups);

            tbl_Menu Menu_Security_Users = new tbl_Menu()
            {
                ID = Guid.NewGuid(),
                ParentID = Menu_Security.ID,

                NameAr = "المستخدمون",
                NameEn = "Users",
                icon = "ion-person-stalker",
                link = "/pages/administration/users",
            };
            fillbase(Menu_Security_Users);

            Menus.Add(Menu_Security);
            Menus.Add(Menu_Security_Groups);
            Menus.Add(Menu_Security_Users);
            foreach (var m in Menus)
            {
                fillbase(m);

                foreach (var m_child in m.Children)
                {
                    fillbase(m_child);
                }

            }
            modelBuilder.Entity<tbl_Menu>().HasData(Menu_Security, Menu_Security_Users, Menu_Security_Groups);

            #endregion
            #endregion
            #region Settings
            tbl_Setting sett1 = new tbl_Setting()
            {

                Conf_Key = "Active_Directory_Domain",
                Conf_Value = "GETGROUP.com"
            };

            fillbase(sett1);
            modelBuilder.Entity<tbl_Setting>().HasData(sett1);


            #endregion

            #region Users
            tbl_User ahmedadmin = new tbl_User()
            {

                Email = "eng.ahmedhassan.eng@gmail.com",
                NameAr = "احمد حسن",
                NameEn = "ahmed hassan",
                Password = "P@ssw0rd",
                isActivated = true,
                Mobile = "01111376958",
                Name = "eng.ahmedhassan.eng@gmail.com",
                ActivationStartDate = DateTime.Now.AddDays(-1),
                ActivationEndDate = null,
                UserTypeID = ut3.ID

            };
            tbl_User user1 = new tbl_User()
            {

                Email = "admin1@mail.com",
                NameAr = "admin1",
                NameEn = "admin1",
                Password = "12345678",
                isActivated = true,
                ActivationStartDate = DateTime.Now.AddDays(-1),
                ActivationEndDate = DateTime.MaxValue
            };
            tbl_User user2 = new tbl_User()
            {

                Email = "admi2n@mail.com",
                NameAr = "admin2",
                NameEn = "admin2",
                Password = "12345678",
                isActivated = true,
                ActivationStartDate = DateTime.Now.AddDays(-1),
                ActivationEndDate = DateTime.MaxValue,

            };
            fillbase(ahmedadmin);
            fillbase(user1);
            fillbase(user2);

            modelBuilder.Entity<tbl_User>().HasData(ahmedadmin);

            List<tbl_Privilligetbl_User> usersInPriv = new List<tbl_Privilligetbl_User>() {

            new tbl_Privilligetbl_User()
            {
                //User = ahmedadmin,
                tbl_User_ID = ahmedadmin.ID,
                tbl_Privillige_ID = Page_Groups.ID,
                //Privillige = Page_Groups
            },
               new tbl_Privilligetbl_User()
               {
                   //User = ahmedadmin,
                   tbl_User_ID = ahmedadmin.ID,
                   tbl_Privillige_ID = Page_Groups_Add.ID,
                   //Privillige = Page_Groups_Add
               },
               new tbl_Privilligetbl_User()
               {
                   //User = ahmedadmin,
                   tbl_User_ID = ahmedadmin.ID,
                   tbl_Privillige_ID = Page_Users.ID,
                   //Privillige = Page_Users
               },
               new tbl_Privilligetbl_User()
               {
                   //User = ahmedadmin,
                   tbl_User_ID = ahmedadmin.ID,
                   tbl_Privillige_ID = Page_Users_Add.ID,
                   //Privillige = Page_Users_Add
               },
             new tbl_Privilligetbl_User()
               {
                   //User = ahmedadmin,
                   tbl_User_ID = ahmedadmin.ID,
                   tbl_Privillige_ID = Page_administration.ID,
                   //Privillige = Page_Users_Add
               }
            };
            //var ahmedadminPriv0 = new tbl_Privilligetbl_User()
            //{
            //    User = ahmedadmin,
            //    Privillige = Page_administration

            //};
            //var ahmedadminPriv1 = new tbl_Privilligetbl_User()
            //{
            //    User = ahmedadmin,
            //    Privillige = Page_Groups

            //};
            //var ahmedadminPriv2 = new tbl_Privilligetbl_User()
            //{
            //    User = ahmedadmin,
            //    Privillige = Page_Users

            //};
            //var ahmedadminPriv3 = new tbl_Privilligetbl_User()
            //{
            //    User = ahmedadmin,
            //    Privillige = Page_Groups_Add

            //};
            //var ahmedadminPriv4 = new tbl_Privilligetbl_User()
            //{
            //    User = ahmedadmin,
            //    Privillige = Page_Users_Add

            //};
            modelBuilder.Entity<tbl_Privilligetbl_User>().HasData(usersInPriv[0], usersInPriv[1], usersInPriv[2], usersInPriv[3], usersInPriv[4]);

            #endregion


            #endregion
            //            context.Database.ExecuteSqlCommand(@"CREATE SEQUENCE [dbo].[ReferenceNmberSequence] 
            // AS[bigint]
            // START WITH 40425942
            // INCREMENT BY 1
            // MINVALUE - 9223372036854775808
            // MAXVALUE 99999999
            // CACHE
            //GO");

            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [tbl_Privillige] OFF");
            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [tbl_Menu] OFF");
        }
        public static void fillbase(tbl_base m)
        {
            if (m.ID == Guid.Empty)
            {
                m.ID = Guid.NewGuid();
            }
            m.CreateDate = DateTime.Now;
            m.CreateUserID = null;
            m.ModifyDate = DateTime.Now;
            m.ModifyUserID = null;
        }
        static string filePathForMigration = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connectionForMigrationOnly.txt");
        static string filePathForProduction = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connectionForProduction.txt");

        public static void UseSqlServerFromConfiguration(this DbContextOptionsBuilder OptionsBuilder)
        {
            DBOptions dBOptions = JsonHelpers<DBOptions>.GetJsonFile("DBConfiguration.json");
            //  string con = System.IO.File.ReadAllText(filePathForMigration);
            if (dBOptions != null && !string.IsNullOrEmpty(dBOptions.Stage))
            {
                string stage = dBOptions.Stage;
                if (stage.ToLower().Contains("memory"))
                {
                    OptionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
                }
                else
                {
                    string con = typeof(DBOptions).GetProperty(stage).GetValue(dBOptions).ToString();
                    OptionsBuilder.UseSqlServer(con);
                }
                OptionsBuilder.EnableSensitiveDataLogging();
            }
        }




    }
}
