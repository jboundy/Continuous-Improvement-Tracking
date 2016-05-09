using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;
using OfficeOpenXml;

namespace Ats.ContinuousImprovement.ImportTool.Helpers
{
    public static class CIDocumentHelpers
    {
        public static CIDocument CreateDocumentFromExcel(ExcelRow row, ExcelWorksheet worksheet)
        {
            var doc = new CIDocument
            {
                CIProjectId = (int)worksheet.Cells[row.Row, 1].Value,
                SiteProjectAppliesTo = (int)worksheet.Cells[row.Row, 2].Value,
            };
            
            return doc;
        }
    }
}
