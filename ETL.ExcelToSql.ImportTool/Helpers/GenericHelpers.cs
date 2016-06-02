using System;
using ETL.ExcelToSql.ImportTool.Models;

namespace ETL.ExcelToSql.ImportTool.Helpers
{
    public static class GenericHelpers
    {
        public static void DisplayTypesOnConsole()
        {
            int count = 1;
            Console.WriteLine("Below are the available types for a column");
            foreach (DataTypes type in Enum.GetValues(typeof(DataTypes)))
            {
                Console.WriteLine($"{count} {type}");
                count++;
            }
        }
    }
}
