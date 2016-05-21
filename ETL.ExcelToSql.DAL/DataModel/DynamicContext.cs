using System.Data.Entity;
using ETL.ExcelToSql.DAL.Models;

namespace ETL.ExcelToSql.DAL.DataModel
{
    public class DynamicContext : DbContext
    {
        public DbSet<DynamicModel> DynamicModels { get; set; }
    }
}
