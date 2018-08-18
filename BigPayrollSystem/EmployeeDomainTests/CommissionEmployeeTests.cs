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
            FakeAddress address = new FakeAddress(new FakeName(), "l1", "city", "country");
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
        public void CommissionEmployees_AreEqual()
        {
            // Arrange
            var employee1 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void CommissionEmployees_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var employee1 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void CommissionEmployees_AreNotEqual()
        {
            // Arrange
            var employee1 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.10m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void CommissionEmployees_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var employee1 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.10m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("f", null, "l", null, null),
                new FakeAddress(),
                new CommissionRate(new CommissionRateValue(0.05m)),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenRateNotSpecified_ThrowsException()
        {
            // Arrange

            Action action = () => CommissionEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "boo", null, null),
                new FakeAddress(new FakeName(), "l1", "city", "country"),
                null,
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act & Assert

            action.Should().Throw<EmployeeDomainException>().WithMessage("Commission rate must not be null.");

            
        }
    }
}