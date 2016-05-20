using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;

namespace Ats.ContinuousImprovement.ImportTool
{
    public class ExcelModel
    {
        public string Worksheet { get; set; }
        public object[] Header { get; set; }
    }

}
