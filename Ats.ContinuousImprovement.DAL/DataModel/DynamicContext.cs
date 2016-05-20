using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;

namespace Ats.ContinuousImprovement.DAL.DataModel
{
    public class DynamicContext : DbContext
    {
        public DbSet<DynamicModel> DynamicModels { get; set; }
    }
}
