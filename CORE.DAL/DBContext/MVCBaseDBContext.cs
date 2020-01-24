using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CORE.DAL.Models.UserManagement;
using CORE.DAL.Models.Menu;
using CORE.DAL.Models;
using Microsoft.Extensions.Options;
using CORE.DAL.infrastructure;
using CORE.common.infrastructure;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using System.Data.Entity.Core.EntityClient;
using CORE.DAL.Migrations;
//using log4net;
using Microsoft.Extensions.Logging;
using CORE.common.infrastructure;

namespace CORE.DAL.DBContext
{
    public partial class MVCBaseDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        DBOptions _DBOptions;

        //public MVCBaseDBContext(DbContextOptions options, IOptions<DBOptions> DBOptions)
        //    : base(options)
        //{
        //    //_DBOptions = DBOptions.Value;


        //    //"name=MVCBaseDBContext"
        //    //this.Configuration.LazyLoadingEnabled = false;
        //}
        #region UserManagement
        public DbSet<tbl_User> Users { get; set; }
        public DbSet<tbl_Group> Groups { get; set; }
        public DbSet<tbl_Privillige> Privilliges { get; set; }
        public DbSet<tbl_Grouptbl_User> tbl_Grouptbl_User { get; set; }
        public DbSet<tbl_Privilligetbl_Group> tbl_Privilligetbl_Group { get; set; }
        public DbSet<tbl_Privilligetbl_User> tbl_Privilligetbl_User { get; set; }




        public DbSet<tbl_UserType> UserTypes { get; set; }

        #endregion
        #region Menu
        public DbSet<tbl_Menu> Menus { get; set; }


        #endregion
        public DbSet<tbl_Setting> Settings { get; set; }

        public DbSet<tbl_GridSettings> GridSettings { get; set; }



        //    public static readonly LoggerFactory MyLoggerFactory
        //= new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //    if (!System.Diagnostics.Debugger.IsAttached)
            //      System.Diagnostics.Debugger.Launch();
            //if (!string.IsNullOrEmpty(_DBOptions.ConnectionString))

            optionsBuilder.UseSqlServerFromConfiguration();


            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<tbl_Grouptbl_User>().HasKey(gu => new { gu.tbl_Group_ID, gu.tbl_User_ID });
            modelBuilder.Entity<tbl_Privilligetbl_Group>().HasKey(gu => new { gu.tbl_Group_ID, gu.tbl_Privillige_ID });
            modelBuilder.Entity<tbl_Privilligetbl_User>().HasKey(gu => new { gu.tbl_Privillige_ID, gu.tbl_User_ID });
            //modelBuilder.Entity<tbl_Grouptbl_User>()
            //    .HasOne<tbl_Group>(sc => sc.Group)
            //    .WithMany(s => s.Users)
            //    .HasForeignKey(sc => sc.);


            modelBuilder.Entity<tbl_Privilligetbl_Group>().HasKey(pg => new { pg.tbl_Privillige_ID, pg.tbl_Group_ID });
            modelBuilder.Entity<tbl_Privilligetbl_User>().HasKey(pu => new { pu.tbl_Privillige_ID, pu.tbl_User_ID });
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<tbl_PrintingQueue>().Property(p => p.PrintingStatus).HasDefaultValue(0);

        //    //modelBuilder.Entity<tbl_PrintingQueue>()
        //    //    .HasOptional(s => s.QueueImages)
        //    //    .WithRequired(ad => ad.PrintingQueue);

        //    //modelBuilder.Entity<PrintLocation>()
        //    //    .HasMany(e => e.PrinterGroups)
        //    //    .WithRequired(e => e.PrintLocation)
        //    //    .HasForeignKey(e => e.LocationId)
        //    //    .WillCascadeOnDelete(false);
        //}
    }
}
