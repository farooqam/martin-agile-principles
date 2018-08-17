using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class CommissionRateValueTests
    {
        [Fact]
        public void CommissionRates_AreEqual()
        {
            // Arrange
            var rate1 = new CommissionRateValue(1m);
            var rate2 = new CommissionRateValue(1m);

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void CommissionRates_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var rate1 = new CommissionRateValue(1m);
            var rate2 = new CommissionRateValue(1m);

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void CommissionRates_AreNotEqual()
        {
            // Arrange
            var rate1 = new CommissionRateValue(1m);
            var rate2 = new CommissionRateValue(0.03m);

            // Act
            var areEqual = rate1 == rate2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void CommissionRates_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var rate1 = new CommissionRateValue(1m);
            var rate2 = new CommissionRateValue(0.03m);

            // Act
            var hashCodesEqual = rate1.GetHashCode() == rate2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenCommissionRate_MoreThanOneHunderedPercent_ThrowException()
        {
            // Arrange
            Action action = () => new CommissionRateValue(1.00001m);

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("Commission rate must be between 0.01 and 1 inclusive.");

            
        }

        [Fact]
        public void WhenCommissionRate_IsLessThanOnePercent_ThrowException()
        {
            // Arrange
            Action action = () => new CommissionRateValue(0m);

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("Commission rate must be between 0.01 and 1 inclusive.");

            
        }
    }
}