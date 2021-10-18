using Microsoft.AspNetCore.Mvc;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMemoryReportStorage _memory;

        public ReportsController(IMemoryReportStorage memory)
        {
            _memory = memory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_memory.Get());
        }
    }
}
