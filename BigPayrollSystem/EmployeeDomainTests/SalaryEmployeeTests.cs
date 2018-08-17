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
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "bee", null, null);
            var address = new FakeAddress();
            var salary = new Money(new FakeCurrency(), new MoneyValue(100000m));

            // Act
            var employee = SalaryEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            employee.EmployeeId.Should().Be(employeeId);
            employee.Name.Should().Be(name);
            employee.Address.Should().Be(address);
            employee.Salary.Should().Be(salary);
        }

        [Fact]
        public void SalaryEmployees_AreEqual()
        {
            // Arrange
            var employee1 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null), 
                new FakeAddress(), 
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null), 
                new FakeAddress(), 
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void SalaryEmployees_AreNotEqual()
        {
            // Arrange
            var employee1 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(200000m)));

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeFalse();

        }

        [Fact]
        public void SalaryEmployees_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var employee1 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void SalaryEmployees_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var employee1 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(100000m)));

            var employee2 = SalaryEmployee.CreateNew(
                new EmployeeId("foo"),
                new Name("bar", null, "bee", null, null),
                new FakeAddress(),
                new Money(new FakeCurrency(), new MoneyValue(200000m)));

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();

        }

        [Fact]
        public void WhenSalaryNotSpecified_ThrowException()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("f", "m", "l", "s", "t");
            var address = new FakeAddress();
            Money salary = null;

            // Act
            Action action = () => SalaryEmployee.CreateNew(employeeId, name, address, salary);

            // Assert
            action.Should().Throw<EmployeeDomainException>().WithMessage("Employee salary must not be null.");
        }
    }
}
