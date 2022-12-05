using DemoProject.Report.Core.Models;
using DemoProject.Report.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.ReportService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<List<ReportModel>> Get() => await _reportService.GetAll();

        [HttpPost(template: "get-by-location")]
        public async Task GetByLocation([FromBody] string location)
        {
        }
    }

}
