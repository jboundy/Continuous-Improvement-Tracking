using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;
using OfficeOpenXml;

namespace Ats.ContinuousImprovement.ImportTool.Helpers
{
    public class ExcelHelpers
    {
        public List<CIDocument> GetDataFromExcel(string filePath)
        {
            List<CIDocument> list = new List<CIDocument>();
            var fileInfo = new FileInfo(filePath);
            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                using (var stream = File.OpenRead(filePath))
                {
                    excelPackage.Load(stream);
                }

                var worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                var lastRow = worksheet.Dimension.End.Row;
                for (int i = 2; i <= lastRow; i++)
                {
                    var document = CIDocumentHelpers.CreateDocumentFromExcel(worksheet.Row(i), worksheet);
                    list.Add(document);
                }
            }

            return list;
        }
    }
}
