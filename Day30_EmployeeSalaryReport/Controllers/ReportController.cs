using Day30_EmployeeSalaryReport.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Day30_EmployeeSalaryReport.Controllers
{
    // [ServiceFilter(typeof(AuthorizationFilter))]
    [Route("reports")]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("salary")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Salary() => Content("Salary report: [confidential]");


    }
}