using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class HourlyRateTests
    {
        [Fact]
        public void HourlyRates_AreEqual()
        {
            // Arrange
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(100m));

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void HourlyRates_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(100m));

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void HourlyRates_AreNotEqual()
        {
            // Arrange
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void HourlyRates_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var rate1 = new HourlyRate(new HourlyRateValue(100m));
            var rate2 = new HourlyRate(new HourlyRateValue(110m));

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenHourlyRateValueNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => new HourlyRate(null);

            // Act & Assert
            action.Should().Throw<EmployeeDomainException>().WithMessage("Hourly rate value must not be null.");

            
        }

    }
}