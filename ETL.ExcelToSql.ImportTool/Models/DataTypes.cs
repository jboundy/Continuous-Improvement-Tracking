using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.ExcelToSql.ImportTool.Models
{
    [Flags]
    public enum DataTypes
    {
        String = 1,
        Integer = 2,
        Boolean = 3,
        Decimal = 4,
        Float = 5,
        Currency = 6,
        DateTime = 7  
    }
}
