using System;
using ETL.ExcelToSql.DAL.Models;
using OfficeOpenXml;

namespace ETL.ExcelToSql.ImportTool.Helpers
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
