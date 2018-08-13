using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class SalariedEmployeeTests
    {
        [Fact]
        public void CreateNew_CreatesSalariedEmployee()
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
            var salary = new Money(currency, salaryAmount);

            // Act
            var newEmployee = SalariedEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            newEmployee.EmployeeId.Should().Be(new EmployeeId(employeeIdValue));
            newEmployee.Name.Should().Be(new Name(firstName, lastName, middleInitial, suffix, title));
            newEmployee.Address.Should().Be(new UnitedStatesAddress(careOf, line1, line2, city, state, country, postalCode));
            newEmployee.Salary.Should().Be(new Money(new UnitedStatesCurrency(), salaryAmount));
        }

        [Fact]
        public void WhenSalaryNull_ThrowException()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("f", "m", "l", "s", "t");
            var address = new UnitedStatesAddress("co", "l1", "l2", "city", "st", "cou", "pc");
            Money salary = null;

            // Act
            Action action = () => SalariedEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            action.Should().Throw<ArgumentException>("Employee salary mus not be null.");
        }
    }
}
