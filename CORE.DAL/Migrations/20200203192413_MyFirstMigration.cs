using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE.DAL.Migrations
{
    public partial class MyFirstMigration : Migration
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
                    { new Guid("491bfc04-49a1-4ade-a486-65bbfb835dd7"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "AdminGroup", "AdminGroup" },
                    { new Guid("ebc4ac81-a089-48a1-9fef-d6c97594161c"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "DoctorGroup", "DoctorGroup" },
                    { new Guid("6fffc88c-495b-42ae-b9a5-19c6cd74cf85"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "PatientGroup", "PatientGroup" }
                });

            migrationBuilder.InsertData(
                table: "Privilliges",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "Key", "ModifyDate", "ModifyUserID", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("ebb49f2c-2b4d-46d4-bd35-f58cdb59262c"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, "Page_Groups", new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "Page_Groups", "Page_Groups" },
                    { new Guid("6c0f378b-0c63-4201-b12b-f2c298518158"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, "Page_Groups_Add", new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "Page_Groups_Add", "Page_Groups_Add" },
                    { new Guid("c3069cd8-684d-431e-b7d1-a08e2334452a"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, "Page_Users", new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "Page_Users", "Page_Users" },
                    { new Guid("746a71b9-2f57-4840-8d15-8028f527134b"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, "Page_Users_Add", new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "Page_Users_Add", "Page_Users_Add" },
                    { new Guid("ce08770d-10d7-4305-a06b-e9c9f499b1c5"), new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, false, "Page_administration", new DateTime(2020, 2, 3, 23, 24, 12, 328, DateTimeKind.Local), null, "Page_administration", "Page_administration" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "ID", "Conf_Key", "Conf_Value", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID" },
                values: new object[] { new Guid("b9ffcc9a-057c-45cb-ae8f-3f0a59b1a46c"), "Active_Directory_Domain", "GETGROUP.com", new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("606a1b07-fc72-4801-9e61-ff2ac353201a"), new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, "مريض", "Patient" },
                    { new Guid("503e61cc-894b-44a4-b63e-52eb82bdfd44"), new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, "طبيب", "Doctor" },
                    { new Guid("89e3f1b8-8970-4556-8c57-daf40d540acd"), new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 326, DateTimeKind.Local), null, "ادارة النظام", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn", "ParentID", "PrivilligeID", "icon", "isPrivate", "link" },
                values: new object[] { new Guid("10cc53ea-fd77-41a1-bdd7-dcb5e392401f"), new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, " الادارة", "administration", null, new Guid("ce08770d-10d7-4305-a06b-e9c9f499b1c5"), "ion-settings", false, "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ActivationEndDate", "ActivationStartDate", "CreateDate", "CreateUserID", "Email", "Image", "IsDeleted", "IsThirdParty", "Mobile", "ModifyDate", "ModifyUserID", "Name", "NameAr", "NameEn", "Password", "Secret", "UserTypeID", "isAD", "isActivated" },
                values: new object[] { new Guid("692da5ee-4567-4b14-abac-943dd49d078d"), null, new DateTime(2020, 2, 2, 23, 24, 12, 330, DateTimeKind.Local), new DateTime(2020, 2, 3, 23, 24, 12, 330, DateTimeKind.Local), null, "eng.ahmedhassan.eng@gmail.com", null, false, false, "01111376958", new DateTime(2020, 2, 3, 23, 24, 12, 330, DateTimeKind.Local), null, "eng.ahmedhassan.eng@gmail.com", "احمد حسن", "ahmed hassan", "P@ssw0rd", null, new Guid("89e3f1b8-8970-4556-8c57-daf40d540acd"), false, true });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CreateDate", "CreateUserID", "IsDeleted", "ModifyDate", "ModifyUserID", "NameAr", "NameEn", "ParentID", "PrivilligeID", "icon", "isPrivate", "link" },
                values: new object[,]
                {
                    { new Guid("68408935-7737-40b2-9b4a-7b73ed185462"), new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, "المستخدمون", "Users", new Guid("10cc53ea-fd77-41a1-bdd7-dcb5e392401f"), null, "ion-person-stalker", false, "/pages/administration/users" },
                    { new Guid("26143422-3000-4289-8cb5-e5eae92a3f01"), new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, false, new DateTime(2020, 2, 3, 23, 24, 12, 329, DateTimeKind.Local), null, "المجموعات", "groups", new Guid("10cc53ea-fd77-41a1-bdd7-dcb5e392401f"), null, "fa fa-object-group", false, "/pages/administration/groups" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Privilligetbl_User",
                columns: new[] { "tbl_Privillige_ID", "tbl_User_ID" },
                values: new object[,]
                {
                    { new Guid("ebb49f2c-2b4d-46d4-bd35-f58cdb59262c"), new Guid("692da5ee-4567-4b14-abac-943dd49d078d") },
                    { new Guid("6c0f378b-0c63-4201-b12b-f2c298518158"), new Guid("692da5ee-4567-4b14-abac-943dd49d078d") },
                    { new Guid("c3069cd8-684d-431e-b7d1-a08e2334452a"), new Guid("692da5ee-4567-4b14-abac-943dd49d078d") },
                    { new Guid("746a71b9-2f57-4840-8d15-8028f527134b"), new Guid("692da5ee-4567-4b14-abac-943dd49d078d") },
                    { new Guid("ce08770d-10d7-4305-a06b-e9c9f499b1c5"), new Guid("692da5ee-4567-4b14-abac-943dd49d078d") }
                });

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
