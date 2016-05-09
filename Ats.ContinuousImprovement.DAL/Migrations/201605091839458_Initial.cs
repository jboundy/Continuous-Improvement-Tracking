namespace Ats.ContinuousImprovement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CIDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CIProjectId = c.Int(nullable: false),
                        SiteProjectAppliesTo = c.Int(nullable: false),
                        SiteName = c.String(),
                        Name = c.String(),
                        ProjectName = c.String(),
                        ProjectLead = c.String(),
                        Sponsor = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedClose = c.DateTime(nullable: false),
                        WorkCompleteDate = c.DateTime(nullable: false),
                        ProjectType = c.String(),
                        ProjectPhase = c.String(),
                        Benefits = c.String(),
                        ProjectStatus = c.String(),
                        ProjectedSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ATSActualSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ATSLevel1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustLevel1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustLevel3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustActualSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FunctionalArea = c.String(),
                        Region = c.String(),
                        OneUpManager = c.String(),
                        Blackbelt = c.String(),
                        Workorder = c.String(),
                        OpenField1 = c.String(),
                        OpenField2 = c.String(),
                        FlagForDeletion = c.Boolean(nullable: false),
                        CustomerExpectedSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AtsExpectedSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeFrameSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DivisionNumber = c.Int(nullable: false),
                        OnePercentLevelOneEligible = c.Int(nullable: false),
                        TwoUpManager = c.String(),
                        ThreeUpManager = c.String(),
                        ActualSavings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovalComments = c.Long(nullable: false),
                        AreaManager = c.String(),
                        AtsLevelOneDetails = c.Long(nullable: false),
                        AtsLevelTwo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AtsLevelTwoDetails = c.Long(nullable: false),
                        AtsLevelThree = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AtsLevelThreeDetails = c.Long(nullable: false),
                        Auditor = c.String(),
                        CheckedOutTo = c.String(),
                        CiNumber = c.Int(nullable: false),
                        Classification = c.String(),
                        Comments = c.Long(nullable: false),
                        CompleteDate = c.DateTime(nullable: false),
                        CompletedDate = c.DateTime(nullable: false),
                        Contributors = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CustFinancialEntryName = c.String(),
                        CustLevelOneDetails = c.Long(nullable: false),
                        CustLevelTwo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustLevelTwoDetails = c.Long(nullable: false),
                        CustLevelThreeDetails = c.Long(nullable: false),
                        CustomerApproval = c.String(),
                        CustomerBlackbelt = c.String(),
                        EmployeeSiteNumber = c.String(),
                        LastAuditDate = c.DateTime(nullable: false),
                        LastAuditDateTwo = c.DateTime(nullable: false),
                        MeetsAuditRequirements = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        NextMeetingDate = c.DateTime(nullable: false),
                        Opprotunity = c.Long(nullable: false),
                        ProcessOwner = c.String(),
                        ProjectApprovalStatus = c.String(),
                        ProjectFlag = c.String(),
                        ReadyForApproval = c.Boolean(nullable: false),
                        SavingsLevel = c.Int(nullable: false),
                        SixSigma = c.Boolean(nullable: false),
                        Solution = c.Long(nullable: false),
                        SubmittedDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        YearOneQuarterOne = c.String(),
                        YearOneQuarterTwo = c.String(),
                        YearOneQuarterThree = c.String(),
                        YearOneQuarterFour = c.String(),
                        YearTwoQuarterOne = c.String(),
                        YearTwoQuarterTwo = c.String(),
                        YearTwoQuarterThree = c.String(),
                        YearTwoQuarterFour = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CIDocuments");
        }
    }
}
