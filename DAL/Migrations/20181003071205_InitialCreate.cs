using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Privilliges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilliges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ID = table.Column<Guid>(nullable: false),
                    Conf_Key = table.Column<string>(nullable: true),
                    Conf_Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    link = table.Column<string>(nullable: true),
                    isPrivate = table.Column<bool>(nullable: false),
                    ParentID = table.Column<Guid>(nullable: true),
                    PrivilligeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Privilliges_PrivilligeID",
                        column: x => x.PrivilligeID,
                        principalTable: "Privilliges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Privilligetbl_Group",
                columns: table => new
                {
                    tbl_Privillige_ID = table.Column<Guid>(nullable: false),
                    tbl_Group_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Privilligetbl_Group", x => new { x.tbl_Privillige_ID, x.tbl_Group_ID });
                    table.UniqueConstraint("AK_tbl_Privilligetbl_Group_tbl_Group_ID_tbl_Privillige_ID", x => new { x.tbl_Group_ID, x.tbl_Privillige_ID });
                    table.ForeignKey(
                        name: "FK_tbl_Privilligetbl_Group_Groups_tbl_Group_ID",
                        column: x => x.tbl_Group_ID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Privilligetbl_Group_Privilliges_tbl_Privillige_ID",
                        column: x => x.tbl_Privillige_ID,
                        principalTable: "Privilliges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    isAD = table.Column<bool>(nullable: false),
                    IsThirdParty = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    UserTypeID = table.Column<Guid>(nullable: true),
                    isActivated = table.Column<bool>(nullable: false),
                    ActivationStartDate = table.Column<DateTime>(nullable: true),
                    ActivationEndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GridSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateUserID = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyUserID = table.Column<Guid>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GridSettings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Grouptbl_User",
                columns: table => new
                {
                    tbl_Group_ID = table.Column<Guid>(nullable: false),
                    tbl_User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Grouptbl_User", x => new { x.tbl_Group_ID, x.tbl_User_ID });
                    table.ForeignKey(
                        name: "FK_tbl_Grouptbl_User_Groups_tbl_Group_ID",
                        column: x => x.tbl_Group_ID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Grouptbl_User_Users_tbl_User_ID",
                        column: x => x.tbl_User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Privilligetbl_User",
                columns: table => new
                {
                    tbl_Privillige_ID = table.Column<Guid>(nullable: false),
                    tbl_User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Privilligetbl_User", x => new { x.tbl_Privillige_ID, x.tbl_User_ID });
                    table.ForeignKey(
                        name: "FK_tbl_Privilligetbl_User_Privilliges_tbl_Privillige_ID",
                        column: x => x.tbl_Privillige_ID,
                        principalTable: "Privilliges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Privilligetbl_User_Users_tbl_User_ID",
                        column: x => x.tbl_User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("5079283c-6e1c-4d86-890f-db366c4aee93"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "AdminGroup", "AdminGroup" },
                    { new Guid("134562ea-20c7-41c1-ae07-a97495b52f3e"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "DoctorGroup", "DoctorGroup" },
                    { new Guid("7d18d419-e865-47a7-a1ac-4a0a13cd74cd"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "PatientGroup", "PatientGroup" }
                });

            migrationBuilder.InsertData(
                table: "Privilliges",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "Key", "ModifyDate", "ModifyUserID", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("35781dc1-4318-460a-8793-bf0fa9466e3c"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, "Page_Groups", new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "Page_Groups", "Page_Groups" },
                    { new Guid("32c2aa7f-b3d9-431b-a2c6-da4f10deaa86"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, "Page_Groups_Add", new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "Page_Groups_Add", "Page_Groups_Add" },
                    { new Guid("b48d59d1-ae93-4f13-9835-87d5796c56cd"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, "Page_Users", new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "Page_Users", "Page_Users" },
                    { new Guid("1513eb3a-835b-492f-bcdd-32bd704b61e1"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, "Page_Users_Add", new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "Page_Users_Add", "Page_Users_Add" },
                    { new Guid("e30604fe-23f3-4db5-8b33-fab4aa012887"), new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, false, "Page_administration", new DateTime(2018, 10, 3, 11, 12, 4, 967, DateTimeKind.Local), null, "Page_administration", "Page_administration" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "ID", "Conf_Key", "Conf_Value", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID" },
                values: new object[] { new Guid("4f9009f4-dbfd-48f0-94d3-528061a73af9"), "Active_Directory_Domain", "GETGROUP.com", new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("917f19f5-c02d-4a0e-b273-65842c47eb1d"), new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, "مريض", "Patient" },
                    { new Guid("31bd4014-8e78-4a12-8cf6-843174efd116"), new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, "طبيب", "Doctor" },
                    { new Guid("8ff7b761-3b68-4a5d-b2ae-9d3a080286b0"), new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 965, DateTimeKind.Local), null, "ادارة النظام", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ActivationEndDate", "ActivationStartDate", "CreateDate", "CreateUserID", "Email", "Image", "IsDeleted", "IsThirdParty", "Mobile", "ModifyDate", "ModifyUserID", "Name", "NameAr", "NameEn", "Password", "Secret", "UserTypeID", "isAD", "isActivated" },
                values: new object[,]
                {
                    { new Guid("2ede22d1-c952-48c6-b896-51ad38d17abf"), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(2018, 10, 2, 11, 12, 4, 968, DateTimeKind.Local), new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, "admin1@mail.com", null, false, false, null, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, null, "admin1", "admin1", "12345678", null, null, false, true },
                    { new Guid("4c3b527e-fa15-4492-920a-67fb60b87d1b"), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified), new DateTime(2018, 10, 2, 11, 12, 4, 968, DateTimeKind.Local), new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, "admi2n@mail.com", null, false, false, null, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, null, "admin2", "admin2", "12345678", null, null, false, true }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn", "ParentID", "PrivilligeID", "icon", "isPrivate", "link" },
                values: new object[] { new Guid("ad0dc644-1514-4927-9cef-e5aae6395dff"), new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, " الادارة", "administration", null, new Guid("e30604fe-23f3-4db5-8b33-fab4aa012887"), "ion-settings", false, "" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn", "ParentID", "PrivilligeID", "icon", "isPrivate", "link" },
                values: new object[] { new Guid("7d03551d-6ecb-47f2-92ad-cb7c60197f93"), new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, "المستخدمون", "Users", new Guid("ad0dc644-1514-4927-9cef-e5aae6395dff"), null, "ion-person-stalker", false, "/pages/administration/users" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn", "ParentID", "PrivilligeID", "icon", "isPrivate", "link" },
                values: new object[] { new Guid("5c9f8c7d-4c3d-4a43-94cb-94be4dc2e804"), new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, false, new DateTime(2018, 10, 3, 11, 12, 4, 968, DateTimeKind.Local), null, "المجموعات", "groups", new Guid("ad0dc644-1514-4927-9cef-e5aae6395dff"), null, "fa fa-object-group", false, "/pages/administration/groups" });

            migrationBuilder.CreateIndex(
                name: "IX_GridSettings_UserID",
                table: "GridSettings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentID",
                table: "Menus",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PrivilligeID",
                table: "Menus",
                column: "PrivilligeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Grouptbl_User_tbl_User_ID",
                table: "tbl_Grouptbl_User",
                column: "tbl_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Privilligetbl_User_tbl_User_ID",
                table: "tbl_Privilligetbl_User",
                column: "tbl_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridSettings");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "tbl_Grouptbl_User");

            migrationBuilder.DropTable(
                name: "tbl_Privilligetbl_Group");

            migrationBuilder.DropTable(
                name: "tbl_Privilligetbl_User");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Privilliges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
