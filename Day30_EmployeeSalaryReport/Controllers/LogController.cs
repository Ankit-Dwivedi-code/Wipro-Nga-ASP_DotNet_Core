using Microsoft.AspNetCore.Mvc;

namespace Day30_EmployeeSalaryReport.Controllers
{
    [Route("logs")]
    public class LogController : Controller
    {
        [HttpGet]
        public IActionResult GetLogs()
        {
            return Content("Log entries...");
        }
    }
}