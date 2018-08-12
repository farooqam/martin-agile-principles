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

        [Route("/salaried")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddSalariedEmployee([FromBody] AddSalariedEmployeeRequestModel model)
        {
            return Ok();
        }

        [Route("/commissioned")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddCommissionedEmployee([FromBody] AddCommissionedEmployeeRequestModel model)
        {
            return Ok();
        }
    }
}