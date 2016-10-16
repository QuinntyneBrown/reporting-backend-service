using ReportingBackendService.Dtos;
using ReportingBackendService.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReportingBackendService.Controllers
{
    [Authorize]
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ReportAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ReportAddOrUpdateRequestDto dto) { return Ok(_reportService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ReportAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ReportAddOrUpdateRequestDto dto) { return Ok(_reportService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ReportDto>))]
        public IHttpActionResult Get() { return Ok(_reportService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ReportDto))]
        public IHttpActionResult GetById(int id) { return Ok(_reportService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_reportService.Remove(id)); }

        protected readonly IReportService _reportService;


    }
}
