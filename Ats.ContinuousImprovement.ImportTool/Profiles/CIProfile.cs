using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ats.ContinuousImprovement.DAL.Models;
using AutoMapper;
using OfficeOpenXml;

namespace Ats.ContinuousImprovement.ImportTool.Profiles
{
    public class CIProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ExcelRange, CIDocument>();
        }
    }
}
