namespace Ats.ContinuousImprovement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CIDocuments");
            AlterColumn("dbo.CIDocuments", "CIProjectId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CIDocuments", "CIProjectId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CIDocuments");
            AlterColumn("dbo.CIDocuments", "CIProjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CIDocuments", "CIProjectId");
        }
    }
}
