using BigCorp.EmployeeApi.Controllers;
using BigCorp.EmployeeApi.RequestModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BigCorp.EmployeeApiTests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _controller = new EmployeeController();
        }

        [Fact]
        public void AddEmployee_AddsAnHourlyEmployee()
        {
            AddHourlyEmployeeRequestModel model = new AddHourlyEmployeeRequestModel
            {
                Id = "143554AEL1223",
                Name = "H.G. Pennypacker",
                Address = "123 Main St, Redmond, WA 98052",
                Rate = 88.75m
            };

            IActionResult response = _controller.AddHourlyEmployee(model);
            response.Should().BeAssignableTo<OkResult>();
        }

        [Fact]
        public void AddEmployee_AddsAnSalariedEmployee()
        {
            AddSalariedEmployeeRequestModel model = new AddSalariedEmployeeRequestModel
            {
                Id = "143554AEL1223",
                Name = "H.G. Pennypacker",
                Address = "123 Main St, Redmond, WA 98052",
                Salary = 150000m
            };

            IActionResult response = _controller.AddSalariedEmployee(model);
            response.Should().BeAssignableTo<OkResult>();
        }

        [Fact]
        public void AddEmployee_AddsACommissionedEmployee()
        {
            AddCommissionedEmployeeRequestModel model = new AddCommissionedEmployeeRequestModel
            {
                Id = "143554AEL1223",
                Name = "H.G. Pennypacker",
                Address = "123 Main St, Redmond, WA 98052",
                Rate = 3.5m,
                Salary = 150000m
            };

            IActionResult response = _controller.AddCommissionedEmployee(model);
            response.Should().BeAssignableTo<OkResult>();
        }
    }
}
