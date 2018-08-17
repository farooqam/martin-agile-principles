using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class CommissionEmployeeTests
    {
        [Fact]
        public void CreateNew_CreatesCommissionEmployee()
        {
            // Arrange
            EmployeeId employeeId = new EmployeeId("foo");
            Name name = new Name("fee", null, "fo", null, null);
            FakeAddress address = new FakeAddress("co", "l1", "city", "country");
            CommissionRate rate = new CommissionRate(new CommissionRateValue(0.03m));
            Money salary = new Money(new FakeCurrency(), new MoneyValue(100000m));

            // Act
            var employee = CommissionEmployee.CreateNew(employeeId, name, address, rate, salary);
        
            // Assert
            employee.EmployeeId.Should().Be(employeeId);
            employee.Name.Should().Be(name);
            employee.Address.Should().Be(address);
            employee.Rate.Should().Be(rate);
            employee.Salary.Should().Be(salary);
        }

        [Fact]
        public void WhenRateNotSpecified_ThrowsException()
        {
            // Arrange

            Action action = () => CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "boo", null, null),
                new FakeAddress("co", "l1", "city", "country"),
                null,
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act & Assert

            action.Should().Throw<ArgumentException>().WithMessage("Commission rate must not be null.");

            
        }
    }
}