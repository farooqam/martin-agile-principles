using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class EmployeeTests
    {
        [Fact]
        public void WhenEmployeeIdNotSpecified_ThrowException()
        {
            //Arrange

            Name name = new Name("first", "mid", "last", "s", "t");
            UnitedStatesAddress address = new UnitedStatesAddress("co", "l1", "l2", "c", "s", "country", "pc");
            EmployeeId employeeId = null;

            Action action = () => new FakeEmployee(employeeId, name, address);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Employee id must not be null.");

        }

        [Fact]
        public void WhenEmployeeNameNotSpecified_ThrowException()
        {
            //Arrange

            Name name = null;
            UnitedStatesAddress address = new UnitedStatesAddress("co", "l1", "l2", "c", "s", "country", "pc");
            EmployeeId employeeId = new EmployeeId("foo");

            Action action = () => new FakeEmployee(employeeId, name, address);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Employee name must not be null.");

        }

        [Fact]
        public void WhenEmployeeAddressNotSpecified_ThrowException()
        {
            //Arrange

            Name name = new Name("first", "mid", "last", "s", "t");
            UnitedStatesAddress address = null;
            EmployeeId employeeId = new EmployeeId("foo");

            Action action = () => new FakeEmployee(employeeId, name, address);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Employee address must not be null.");

        }
    }

    public class FakeEmployee : Employee
    {
        public FakeEmployee(EmployeeId employeeId, Name name, Address address) : base(employeeId, name, address)
        {
        }
    }
}
