using System.Data.SqlTypes;
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
            UnitedStatesCurrency currency = new UnitedStatesCurrency();
            Money salary = new Money(currency, 150000m);

            // Act
            var newEmployee = SalariedEmployee.CreateNew(employeeId, name, address);

            // Assert
            newEmployee.EmployeeId.Should().Be(new EmployeeId(employeeIdValue));
            newEmployee.Name.Should().Be(new Name(firstName, lastName, middleInitial, suffix, title));
            newEmployee.Address.Should().Be(new UnitedStatesAddress(careOf, line1, line2, city, state, country, postalCode));
        }
    }
}
