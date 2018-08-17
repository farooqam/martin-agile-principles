using System;
using BigCorp.EmployeeDomain;
using BigCorp.Utility;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employees_AreEqual()
        {
            // Arrange
            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            
            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Employees_WhenEqual_HaveSameHashCodes()
        {
            // Arrange
            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Employees_WhenIdNotEqual_AreNotEqual()
        {
            // Arrange
            
            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("bar", null, "bee", null, null), new FakeAddress());

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Employees_WhenIdNotEqual_HaveDifferentHashCodes()
        {
            // Arrange

            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("bar", null, "bee", null, null), new FakeAddress());

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void Employees_WhenNameNotEqual_AreNotEqual()
        {
            // Arrange
            
            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("hoo", null, "bee", null, null), new FakeAddress());

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Employees_When_NameNotEqual_HaveDifferentHashCodes()
        {
            // Arrange

            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("hoo", null, "bee", null, null), new FakeAddress());

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void Employees_WhenAddressNotEqual_AreNotEqual()
        {
            // Arrange
            
            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("hoo", null, "bee", null, null), new FakeAddress("co", "zzz", "ggg", "uuu"));

            // Act
            var areEqual = employee1 == employee2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Employees_WhenAddressNotEqual_HaveDifferentHashCodes()
        {
            // Arrange

            var employee1 = new FakeEmployee(new EmployeeId("foo"), new Name("bar", null, "bee", null, null), new FakeAddress());
            var employee2 = new FakeEmployee(new EmployeeId("bar"), new Name("hoo", null, "bee", null, null), new FakeAddress("co", "zzz", "ggg", "uuu"));

            // Act
            var hashCodesEqual = employee1.GetHashCode() == employee2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

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

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().Add(base.CalculateHashCode());
        }
        
    }
}
