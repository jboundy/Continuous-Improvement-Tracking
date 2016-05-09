using System.Data.Entity;
using Ats.ContinuousImprovement.DAL.Models;

namespace Ats.ContinuousImprovement.DAL.DataModel
{
    public class CIContext : DbContext
    {
        public DbSet<CIDocument> CiDocuments { get; set; }
    }
}
