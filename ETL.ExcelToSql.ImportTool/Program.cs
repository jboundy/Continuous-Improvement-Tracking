using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using ETL.ExcelToSql.BLL;
using ETL.ExcelToSql.DAL.Migrations;
using ETL.ExcelToSql.DAL.Models;
using ETL.ExcelToSql.ImportTool.Helpers;

namespace ETL.ExcelToSql.ImportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file");
            var input = Console.ReadLine();
            Console.WriteLine("Enter the name for the database (Note: it will render as dbo.tablename");
            var databaseName = Console.ReadLine();
            GenericHelpers.DisplayTypesOnConsole();
            var excelHelper = new ExcelHelpers(input);
            var excelObjects = excelHelper.GetHeadersFromExcel();
            var setTypes = excelHelper.SetTypesFromInput(excelObjects);
            //use headers to create a class object
            foreach (var setType in setTypes)
            {
                
            }
            var something = new EtlClassBuilder("Assembly", "something");
            var baseObject = something.CreateNewClass(setTypes);
            //create database from class object
            var config = new Configuration();
            //get data to import to database
            var import = excelHelper.GetDataFromExcel();



            //using (var context = new DynamicContext())
            //{
            //    context.DynamicModels.AddRange();
            //    context.SaveChanges();
            //}
            excelHelper.Dispose();
        }
    }
}
