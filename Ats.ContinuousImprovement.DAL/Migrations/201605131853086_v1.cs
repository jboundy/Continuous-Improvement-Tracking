namespace Ats.ContinuousImprovement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CIDocuments");
            AddPrimaryKey("dbo.CIDocuments", "CIProjectId");
            DropColumn("dbo.CIDocuments", "Id");
            DropColumn("dbo.CIDocuments", "SiteProjectAppliesTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIDocuments", "SiteProjectAppliesTo", c => c.Int(nullable: false));
            AddColumn("dbo.CIDocuments", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CIDocuments");
            AddPrimaryKey("dbo.CIDocuments", "Id");
        }
    }
}
