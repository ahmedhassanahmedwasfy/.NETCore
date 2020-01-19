namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_user_4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_Grouptbl_User", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.tbl_Grouptbl_User1", newName: "tbl_Grouptbl_User");
            RenameTable(name: "__mig_tmp__0", newName: "tbl_Grouptbl_User1");
            RenameColumn(table: "dbo.tbl_Grouptbl_User", name: "tbl_Group_ID", newName: "GroupID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User", name: "tbl_User_ID", newName: "UserID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User", name: "IX_tbl_User_ID", newName: "IX_UserID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User", name: "IX_tbl_Group_ID", newName: "IX_GroupID");
            DropPrimaryKey("dbo.tbl_Grouptbl_User");
            AddPrimaryKey("dbo.tbl_Grouptbl_User", new[] { "UserID", "GroupID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_Grouptbl_User");
            AddPrimaryKey("dbo.tbl_Grouptbl_User", new[] { "tbl_Group_ID", "tbl_User_ID" });
            RenameIndex(table: "dbo.tbl_Grouptbl_User", name: "IX_GroupID", newName: "IX_tbl_Group_ID");
            RenameIndex(table: "dbo.tbl_Grouptbl_User", name: "IX_UserID", newName: "IX_tbl_User_ID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User", name: "UserID", newName: "tbl_User_ID");
            RenameColumn(table: "dbo.tbl_Grouptbl_User", name: "GroupID", newName: "tbl_Group_ID");
            RenameTable(name: "tbl_Grouptbl_User1", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.tbl_Grouptbl_User", newName: "tbl_Grouptbl_User1");
            RenameTable(name: "dbo.__mig_tmp__0", newName: "tbl_Grouptbl_User");
        }
    }
}
