using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class HourlyEmployeeTests
    {
        [Fact]
        public void CreateNew_CreatesHourlyEmployee()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            var rate = new HourlyRate(new HourlyRateValue(110m));

            // Act
            var employee = HourlyEmployee.CreateNew(employeeId, name, address, rate);

            // Assert
            employee.EmployeeId.Should().Be(employeeId);
            employee.Name.Should().Be(name);
            employee.Address.Should().Be(address);
            employee.Rate.Should().Be(rate);

        }

        [Fact]
        public void HourlyEmployees_AreEqual()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            var rate1 = new HourlyRate(new HourlyRateValue(110m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            var employee1 = HourlyEmployee.CreateNew(employeeId, name, address, rate1);
            var employee2 = HourlyEmployee.CreateNew(employeeId, name, address, rate2);

            // Act
            var areEqual = employee1 == employee2;  

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void HourlyEmployees_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            var rate1 = new HourlyRate(new HourlyRateValue(110m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            var employee1 = HourlyEmployee.CreateNew(employeeId, name, address, rate1);
            var employee2 = HourlyEmployee.CreateNew(employeeId, name, address, rate2);

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();  

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void HourlyEmployees_AreNotEqual()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            var employee1 = HourlyEmployee.CreateNew(employeeId, name, address, rate1);
            var employee2 = HourlyEmployee.CreateNew(employeeId, name, address, rate2);

            // Act
            var areEqual = employee1 == employee2;  

            // Assert
            areEqual.Should().BeFalse();

        }

        [Fact]
        public void HourlyEmployees_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            var employee1 = HourlyEmployee.CreateNew(employeeId, name, address, rate1);
            var employee2 = HourlyEmployee.CreateNew(employeeId, name, address, rate2);

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();

        }

        [Fact]
        public void WhenHorlyRateNotSpecified_ThrowException()
        {
            // Arrange
            var employeeId = new EmployeeId("foo");
            var name = new Name("bar", null, "hee", null, null);
            var address = new FakeAddress();
            Action action = () => HourlyEmployee.CreateNew(employeeId, name, address, null);

            // Act & Assert
            action.Should().Throw<EmployeeDomainException>().WithMessage("Hourly rate must not be null.");

            
        }
    }
}