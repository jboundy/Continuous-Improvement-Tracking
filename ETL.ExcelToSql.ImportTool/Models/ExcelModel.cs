using System;
using System.Collections.Generic;

namespace ETL.ExcelToSql.ImportTool.Models
{
    public class ExcelModel
    {
        public string Worksheet { get; set; }
        public object[] Header { get; set; }
        public Type Type { get; set; }
    }
}
