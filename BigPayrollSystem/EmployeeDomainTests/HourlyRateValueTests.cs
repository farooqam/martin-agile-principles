using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class HourlyRateValueTests
    {
        [Fact]
        public void HourlyRates_AreEqual()
        {
            // Arrange
            var rate1 = new HourlyRateValue(100m);
            var rate2 = new HourlyRateValue(100m);

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void HourlyRates_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var rate1 = new HourlyRateValue(100m);
            var rate2 = new HourlyRateValue(100m);

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void HourlyRates_AreNotEqual()
        {
            // Arrange
            var rate1 = new HourlyRateValue(100m);
            var rate2 = new HourlyRateValue(110m);

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void HourlyRates_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var rate1 = new HourlyRateValue(100m);
            var rate2 = new HourlyRateValue(110m);

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenHourlyRateNegative_ThrowException()
        {
            // Arrange
            Action action = () => new HourlyRateValue(-1);

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("Hourly rate value must be greater than zero.");

            
        }
    }
}