using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class CommissionRateTests
    {
        [Fact]
        public void CommissionRates_AreEqual()
        {
            // Arrange
            var rate1 = new CommissionRate(new CommissionRateValue(0.01m));
            var rate2 = new CommissionRate(new CommissionRateValue(0.01m));

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void CommissionRates_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var rate1 = new CommissionRate(new CommissionRateValue(0.01m));
            var rate2 = new CommissionRate(new CommissionRateValue(0.01m));

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void CommissionRates_AreNotEqual()
        {
            // Arrange
            var rate1 = new CommissionRate(new CommissionRateValue(0.01m));
            var rate2 = new CommissionRate(new CommissionRateValue(0.02m));

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeFalse();

        }

        [Fact]
        public void CommissionRates_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var rate1 = new CommissionRate(new CommissionRateValue(0.01m));
            var rate2 = new CommissionRate(new CommissionRateValue(0.02m));

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();

        }

        [Fact]
        public void WhenCommisionRateValueNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => new CommissionRate(null);

            // Act & Assert
            action.Should().Throw<EmployeeDomainException>().WithMessage("Commission rate value must not be null.");

            
        }
    }
}