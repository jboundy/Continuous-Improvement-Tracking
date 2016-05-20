using System;
using System.Data.Entity;
using Ats.ContinuousImprovement.BLL;
using Ats.ContinuousImprovement.DAL.Models;
using Ats.ContinuousImprovement.ImportTool.Helpers;

namespace Ats.ContinuousImprovement.ImportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file");
            var input = Console.ReadLine();
            var excelHelper = new ExcelHelpers(input);
            //grab headers from excel
            var excelObjects = excelHelper.GetHeadersFromExcel();        
            //use headers to create a class object
            foreach (var exObj in excelObjects)
            {
                //if (!Database.Exists(exObj))
                //{
                //    var atsObject = new AtsTypeBuilder(exObj.WorkSheet, exObj.ColumnName);
                //}
            }
            //create database from class object
            //get data to import to database
            var import = excelHelper.GetDataFromExcel<DynamicModel>();
            //using (var context = new DynamicContext())
            //{
            //    context.DynamicModels.AddRange();
            //    context.SaveChanges();
            //}
            excelHelper.Dispose();
        }
    }
}
