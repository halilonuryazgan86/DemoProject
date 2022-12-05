using DemoProject.Core;
using DemoProject.Report.Core.Models;
using DemoProject.ReportWorker.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject.ReportWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ApiUrlModel _apiUrlModel;
        public Worker(ILogger<Worker> logger, ApiUrlModel apiUrlModel)
        {
            _logger = logger;
            _apiUrlModel = apiUrlModel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var extension = new HttpExtension();

                var result = extension.GetResponse<List<HttpResponseReportModel>, object>(new DemoProject.Core.Models.HttpRequest<object> { RequestUrl = $"{_apiUrlModel.ReportServiceUrl}api/report", RequestType = DemoProject.Core.Models.HttpRequestType.GET });

                _logger.LogInformation($"Tamamlanan: {result.ResponseObject.Count(x => x.Durum == ReportType.Completed)} - Devam Eden: {result.ResponseObject.Count(x => x.Durum == ReportType.Preparing)} ");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
