using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ETL.ExcelToSql.DAL.Models;
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

        //todo: need to unflatten the list so that lits of fields return for each class to create based on table
        public List<DynamicModel> SetTypesFromInput(IEnumerable<ExcelModel> models)
        {
            List<DynamicModel> list = new List<DynamicModel>();
            foreach (var model in models)
            {
                foreach (var h in model.Header)
                {
                    var header = h.ToString();
                    Console.WriteLine($"Please choose type for {header}");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(string)
                            });
                            break;
                        case "2":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(int)
                            });
                            break;
                        case "3":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(bool)
                            });
                            break;
                        case "4":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(decimal)
                            });
                            break;
                        case "5":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(float)
                            });
                            break;
                        case "6":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(CurrencyWrapper)
                            });
                            break;
                        case "7":
                            list.Add(new DynamicModel
                            {
                                FieldName = header,
                                FieldType = typeof(DateTime)
                            });
                            break;
                    }
                }

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

        public IEnumerable<DataTable> GetDataFromExcel()
        {
            var dataTable = ConvertToDataTables(_excelWorksheets);
            return dataTable;
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}
