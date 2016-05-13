using System;
using Ats.ContinuousImprovement.DAL.DataModel;
using Ats.ContinuousImprovement.ImportTool.Helpers;

namespace Ats.ContinuousImprovement.ImportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ExcelRange, CIDocument>();
            //    cfg.CreateProfile("CIProfile");
            //});
            Console.WriteLine("Enter path to file");
            var input = Console.ReadLine();
            var excelHelper = new ExcelHelpers();
            var import = excelHelper.GetDataFromExcel(input);
            using (var context = new CIContext())
            {
                context.CiDocuments.AddRange(import);
                context.SaveChanges();
            }
        }
    }
}
