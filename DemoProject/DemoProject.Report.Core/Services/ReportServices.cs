using DemoProject.Report.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Report.Core.Services
{
    public interface IReportService
    {
        Task<List<ReportModel>> GetAll();
        Task<List<ReportModel>> InsertReport(ReportModel request);
    }
    public class ReportServices : IReportService
    {
        private readonly DemoProject.Core.MongoDB.MongoDBConnectionSetting _mongoDBConnectionSetting;
        private readonly IReportRepository _reportRepository;
        public ReportServices(DemoProject.Core.MongoDB.MongoDBConnectionSetting mongoDBConnectionSetting,
            IReportRepository reportRepository)
        {
            _mongoDBConnectionSetting = mongoDBConnectionSetting;
            _reportRepository = reportRepository;
        }

        public async Task<List<ReportModel>> GetAll() => await _reportRepository.GetListAsync();

        public async Task<List<ReportModel>> InsertReport(ReportModel request)
        {
            await _reportRepository.InsertItemAsync(request);
            return await _reportRepository.GetListAsync();
        }
    }
}
