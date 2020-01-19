namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_user : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
