using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace Ats.ContinuousImprovement.ImportTool.Helpers
{
    public static class GenericHelpers
    {
        public static DynamicModel CreateObjectFromExcel(ExcelRow row, ExcelWorksheet worksheet)
        {
            var doc = new DynamicModel();
            {

            };

            return doc;
        }

        private static int ToInt(this object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
