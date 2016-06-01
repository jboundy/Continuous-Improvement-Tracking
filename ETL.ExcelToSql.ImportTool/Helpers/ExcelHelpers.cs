using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ETL.ExcelToSql.DAL.Models;
using ETL.ExcelToSql.ImportTool.Models;
using OfficeOpenXml;
using ExcelModel = ETL.ExcelToSql.ImportTool.Models.ExcelModel;

namespace ETL.ExcelToSql.ImportTool.Helpers
{
    public class ExcelHelpers : IDisposable
    {
        private readonly ExcelWorksheets _excelWorksheets;
        private readonly FileStream _stream;
        public ExcelHelpers(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var ep = new ExcelPackage(fileInfo);
            _stream = File.OpenRead(filePath);
            ep.Load(_stream);
            _excelWorksheets = ep.Workbook.Worksheets;
        }

        public List<ExcelModel> GetHeadersFromExcel()
        {
            List<ExcelModel> list = new List<ExcelModel>();
            var data = ConvertToDataTables(_excelWorksheets);
            foreach (var col in data)
            {
                var model = new ExcelModel
                {
                    Header = new object[col.Columns.Count]
                };
                for (int i = 0; i < col.Columns.Count; i++)
                {
                    model.Header[i] = col.Columns[i].ColumnName;
                    model.Worksheet = col.TableName;
                }
                list.Add(model);
            }
            return list;
        }

        //todo: need to seperate function...probably move the enumeration to its own method
        public Dictionary<string,Type> SetTypesFromInput(IEnumerable<ExcelModel> models)
        {
            Dictionary<string, Type> dict = new Dictionary<string, Type>();
            int count = 1;
            var arrayModels = models.ToArray();
            Console.Write("Below are the available types for a column");
            foreach (DataTypes type in Enum.GetValues(typeof(DataTypes)))
            {
                Console.WriteLine($"{count} {type}");
                count++;
            }
            for (int i = 0; i < arrayModels.Length; i++)
            {
                var header = arrayModels[i].Header[i];
                Console.WriteLine($"Please choose type for {header}");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        dict.Add(header.ToString(), typeof(String));
                        break;
                    case "2":
                        dict.Add(header.ToString(), typeof(Int32));
                        break;
                    case "3":
                        dict.Add(header.ToString(), typeof(Boolean));
                        break;
                    case "4":
                        dict.Add(header.ToString(), typeof(Decimal));
                        break;
                    case "5":
                        dict.Add(header.ToString(), typeof(float));
                        break;
                    case "6":
                        dict.Add(header.ToString(), typeof(CurrencyWrapper));
                        break;
                    case "7":
                        dict.Add(header.ToString(), typeof(DateTime));
                        break;
                }
            }

            return dict;
        }


        public List<DynamicModel> MapToDynamicModels(Dictionary<string, Type> dict)
        {
            List<DynamicModel> list = new List<DynamicModel>();
            foreach (var item in dict)
            {
                var dm = new DynamicModel
                {
                    FieldName = item.Key,
                    FieldType = item.Value
                };

                list.Add(dm);
            }
            return list;
        }

        private static IEnumerable<DataTable> ConvertToDataTables(ExcelWorksheets worksheets)
        {
            List<DataTable> dataTable = new List<DataTable>();
            foreach (var worksheet in worksheets)
            {
                DataTable tbl = new DataTable(worksheet.Name);
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                {
                    tbl.Columns.Add(firstRowCell.Text);
                }
                for (int rowNum = 2; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                {
                    var worksheetRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in worksheetRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    tbl.Rows.Add(row);
                }
                dataTable.Add(tbl);
            }
            return dataTable;
        }

        public IEnumerable<T> GetDataFromExcel<T>()
        {
            List<T> list = new List<T>();
            foreach (var worksheet in _excelWorksheets)
            {
                var lastRow = worksheet.Dimension.End.Row;
            }
           
            //for (int i = 2; i <= lastRow; i++)
            //{
            //    var document = CIDocumentHelpers.CreateDocumentFromExcel(worksheet.Row(i), worksheet);
            //    list.Add(document);
            //}

            return list;
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}
