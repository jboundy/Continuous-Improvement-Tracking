using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.DataModel;
using Ats.ContinuousImprovement.DAL.Models;
using Ats.ContinuousImprovement.ImportTool.Helpers;
using Ats.ContinuousImprovement.ImportTool.Profiles;
using AutoMapper;
using OfficeOpenXml;

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
