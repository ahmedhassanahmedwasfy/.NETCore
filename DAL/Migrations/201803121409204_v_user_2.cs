namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_user_2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_Grouptbl_User", newName: "tbl_Grouptbl_User1");
            RenameColumn(table: "dbo.tbl_Grouptbl_User1", name: "UserID", newName: "tbl_User_ID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User1", name: "GroupID", newName: "tbl_Group_ID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User1", name: "IX_GroupID", newName: "IX_tbl_Group_ID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User1", name: "IX_UserID", newName: "IX_tbl_User_ID");
            DropPrimaryKey("dbo.tbl_Grouptbl_User1");
            CreateTable(
                "dbo.tbl_Grouptbl_User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.UserID);
            
            AddPrimaryKey("dbo.tbl_Grouptbl_User1", new[] { "tbl_Group_ID", "tbl_User_ID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Grouptbl_User", "UserID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_Grouptbl_User", "GroupID", "dbo.tbl_Group");
            DropIndex("dbo.tbl_Grouptbl_User", new[] { "UserID" });
            DropIndex("dbo.tbl_Grouptbl_User", new[] { "GroupID" });
            DropPrimaryKey("dbo.tbl_Grouptbl_User1");
            DropTable("dbo.tbl_Grouptbl_User");
            AddPrimaryKey("dbo.tbl_Grouptbl_User1", new[] { "UserID", "GroupID" });
            RenameIndex(table: "dbo.tbl_Grouptbl_User1", name: "IX_tbl_User_ID", newName: "IX_UserID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User1", name: "IX_tbl_Group_ID", newName: "IX_GroupID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User1", name: "tbl_Group_ID", newName: "GroupID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User1", name: "tbl_User_ID", newName: "UserID");
            RenameTable(name: "dbo.tbl_Grouptbl_User1", newName: "tbl_Grouptbl_User");
        }
    }
}
