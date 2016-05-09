using System;

namespace Ats.ContinuousImprovement.DAL.Models
{
    public class CIDocument
    {
        public int Id { get; set; }
        public object CIProjectId { get; set; }
        public object SiteProjectAppliesTo { get; set; }
        public string SiteName { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLead { get; set; }
        public string Sponsor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedClose { get; set; }
        public DateTime WorkCompleteDate { get; set; }
        public string ProjectType { get; set; }
        public string ProjectPhase { get; set; }
        public string Benefits { get; set; }
        public string ProjectStatus { get; set; }
        public decimal ProjectedSavings { get; set; }
        public decimal ATSActualSavings { get; set; }
        public decimal ATSLevel1 { get; set; }
        public decimal CustLevel1 { get; set; }
        public decimal CustLevel3 { get; set; }
        public decimal CustActualSavings { get; set; }
        public string FunctionalArea { get; set; }
        public string Region { get; set; }
        public string OneUpManager { get; set; }
        public string Blackbelt { get; set; }
        public string Workorder { get; set; }
        public string OpenField1 { get; set; }
        public string OpenField2 { get; set; }
        public bool FlagForDeletion { get; set; }
        public decimal CustomerExpectedSavings { get; set; }
        public decimal AtsExpectedSavings { get; set; }
        public decimal TimeFrameSavings { get; set; }
        public int DivisionNumber { get; set; }
        public int OnePercentLevelOneEligible { get; set; }
        public string TwoUpManager { get; set; }
        public string ThreeUpManager { get; set; }
        public decimal ActualSavings { get; set; }
        public long ApprovalComments { get; set; }
        public string AreaManager { get; set; }
        public long AtsLevelOneDetails { get; set; }
        public decimal AtsLevelTwo { get; set; }
        public long AtsLevelTwoDetails { get; set; }

        public decimal AtsLevelThree { get; set; }
        public long AtsLevelThreeDetails { get; set; }
        public string Auditor { get; set; }
        public string CheckedOutTo { get; set; }
        public int  CiNumber { get; set; }
        public string Classification { get; set; }
        public long Comments { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Contributors { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string CustFinancialEntryName { get; set; }
        public long CustLevelOneDetails { get; set; }
        public decimal CustLevelTwo { get; set; }
        public long CustLevelTwoDetails { get; set; }
        public long CustLevelThreeDetails { get; set; }
        public string CustomerApproval { get; set; }
        public string CustomerBlackbelt { get; set; }
        public string EmployeeSiteNumber { get; set; }
        public DateTime LastAuditDate { get; set; }
        public DateTime LastAuditDateTwo { get; set; }
        public bool MeetsAuditRequirements { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime NextMeetingDate { get; set; }
        public long Opprotunity { get; set; }
        public string ProcessOwner { get; set; }
        public string ProjectApprovalStatus { get; set; }
        public string ProjectFlag { get; set; }
        public bool ReadyForApproval { get; set; }
        public int SavingsLevel { get; set; }
        public bool SixSigma { get; set; }
        public long Solution { get; set; }
        public DateTime SubmittedDate{ get; set; }
        public string Title { get; set; }
        public string YearOneQuarterOne { get; set; }
        public string YearOneQuarterTwo { get; set; }
        public string YearOneQuarterThree { get; set; }
        public string YearOneQuarterFour { get; set; }
        public string YearTwoQuarterOne { get; set; }
        public string YearTwoQuarterTwo { get; set; }
        public string YearTwoQuarterThree { get; set; }
        public string YearTwoQuarterFour { get; set; }

    }
}
