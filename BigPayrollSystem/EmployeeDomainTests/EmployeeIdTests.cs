using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class EmployeeIdTests
    {
        [Fact]
        public void EmployeeIdValue_MustBeSpecified()
        {
            Action action = () => new EmployeeId(string.Empty);
            action.Should().Throw<ArgumentException>().WithMessage("Employee id value cannot be a null or empty string.");
        }

        [Fact]
        public void EmployeeIds_AreEqual()
        {
            // Arrange
            var id1 = new EmployeeId("foo");
            var id2 = new EmployeeId("foo");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void EmployeeIds_WhenDifferingByCase_AreEqual()
        {
            // Arrange
            var id1 = new EmployeeId("FOO");
            var id2 = new EmployeeId("foo");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void EmployeeIds_WhenDifferingByCase_HaveTheSameHashCodes()
        {
            // Arrange
            var id1 = new EmployeeId("FOO");
            var id2 = new EmployeeId("foo");

            // Act
            var hashCodesAreEqual = (id1.GetHashCode() == id2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeTrue();
        }

        [Fact]
        public void EmployeeIds_WhenEqual_HaveTheSameHashCode()
        {
            // Arrange
            var id1 = new EmployeeId("foo");
            var id2 = new EmployeeId("foo");

            // Act
            var hashCodesAreEqual = (id1.GetHashCode() == id2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeTrue();
        }


        [Fact]
        public void EmployeeIds_AreNotEqual()
        {
            // Arrange
            var id1 = new EmployeeId("bar");
            var id2 = new EmployeeId("foo");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void EmployeeIds_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var id1 = new EmployeeId("bar");
            var id2 = new EmployeeId("foo");

            // Act
            var hashCodesAreEqual = (id1.GetHashCode() == id2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeFalse();
        }
    }
}
