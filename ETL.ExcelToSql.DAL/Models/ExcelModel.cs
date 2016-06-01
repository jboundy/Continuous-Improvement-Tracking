using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.ExcelToSql.DAL.Models
{
    public class ExcelModel
    {
        public string Worksheet { get; set; }
        public object[] Header { get; set; }
        public Type Type { get; set; }
    }
}
