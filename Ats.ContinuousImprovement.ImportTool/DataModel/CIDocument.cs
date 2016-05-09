using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.ContinuousImprovement.ImportTool.DataModel
{
    class CIDocument
    {
        public int CIProjectId { get; set; }
        public int SiteProjectAppliesTo { get; set; }
        public string SiteName { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLead { get; set; }
        public string Sponsor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedClose { get; set; }
        public DateTime WorkCompleteDate { get; set; }
        public string ProjectType { get; set; }
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
    }
}
