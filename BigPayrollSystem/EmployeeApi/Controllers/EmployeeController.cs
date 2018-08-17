using System.Net;
using BigCorp.EmployeeApi.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BigCorp.EmployeeApi.Controllers
{

    [Route("api/v1.0/employee")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        [Route("/hourly")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddHourlyEmployee([FromBody] AddHourlyEmployeeRequestModel model)
        {
            return Ok();
        }

        [Route("/salary")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddSalaryEmployee([FromBody] AddSalaryEmployeeRequestModel model)
        {
            return Ok();
        }

        [Route("/commission")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddCommissionEmployee([FromBody] AddCommissionEmployeeRequestModel model)
        {
            return Ok();
        }
    }
}