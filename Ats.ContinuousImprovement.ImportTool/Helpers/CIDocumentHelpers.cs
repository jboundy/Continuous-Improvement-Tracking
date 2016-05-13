using System;
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
                CIProjectId = worksheet.Cells[row.Row, 1].Value.ToInt(),
                SiteProjectAppliesTo = worksheet.Cells[row.Row, 2].Value.ToInt(),
            };
            
            return doc;
        }

        private static int ToInt(this object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
