using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class SalaryEmployeeTests
    {
        [Fact]
        public void CreateNew_CreatesSalaryEmployee()
        {
            // Arrange
            var employeeIdValue = "foo";
            var employeeId = new EmployeeId(employeeIdValue);

            var firstName = "foo";
            var lastName = "bar";
            var middleInitial = "qux";
            var suffix = "baz";
            var title = "boo";

            var name = new Name(firstName, lastName, middleInitial, suffix, title);

            var careOf = "foo";
            var line1 = "bar";
            var line2 = "bee";
            var city = "boo";
            var state = "hee";
            var country = "haw";
            var postalCode = "bum";

            var address = new UnitedStatesAddress(careOf, line1, line2, city, state, country, postalCode);

            var salaryAmount = 150000m;
            var currency = new UnitedStatesCurrency();
            var salary = new Money(currency, new MoneyValue(salaryAmount));

            // Act
            var newEmployee = SalaryEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            newEmployee.EmployeeId.Should().Be(new EmployeeId(employeeIdValue));
            newEmployee.Name.Should().Be(new Name(firstName, lastName, middleInitial, suffix, title));
            newEmployee.Address.Should().Be(new UnitedStatesAddress(careOf, line1, line2, city, state, country, postalCode));
            newEmployee.Salary.Should().Be(new Money(new UnitedStatesCurrency(), new MoneyValue(salaryAmount)));
        }

        [Fact]
        public void WhenSalaryNotSpecified_ThrowException()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("f", "m", "l", "s", "t");
            var address = new UnitedStatesAddress("co", "l1", "l2", "city", "st", "cou", "pc");
            Money salary = null;

            // Act
            Action action = () => SalaryEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Employee salary must not be null.");
        }
    }
}
