using DemoProject.Core.MongoDB;
using DemoProject.Report.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Report.Core.Services
{
    public interface IReportRepository : IBaseRepository<ReportModel>
    {

    }
    public class ReportRepository : BaseRepository<ReportModel>, IReportRepository
    {
        public ReportRepository(MongoDBConnectionSetting mongoDBConnectionSetting) : base(mongoDBConnectionSetting)
        {
        }
    }
}
