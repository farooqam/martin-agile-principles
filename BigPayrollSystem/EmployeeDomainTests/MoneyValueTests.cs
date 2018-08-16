using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class MoneyValueTests
    {
        [Fact]
        public void MoneyValues_AreEqual()
        {
            // Arrange
            var moneyValue1 = new MoneyValue(100m);
            var moneyValue2 = new MoneyValue(100m);

            // Act
            var areEqual = moneyValue1 == moneyValue2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void MoneyValues_WhenEqual_HaveTheSameHashCode()
        {
            // Arrange
            var moneyValue1 = new MoneyValue(100m);
            var moneyValue2 = new MoneyValue(100m);

            // Act
            var hashCodesEqual = moneyValue1.GetHashCode() == moneyValue2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void MoneyValues_AreNotEqual()
        {
            // Arrange
            var moneyValue1 = new MoneyValue(100m);
            var moneyValue2 = new MoneyValue(100.0001m);

            // Act
            var areEqual = moneyValue1 == moneyValue2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void MoneyValues_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var moneyValue1 = new MoneyValue(100m);
            var moneyValue2 = new MoneyValue(100.0001m);

            // Act
            var hashCodesEqual = moneyValue1.GetHashCode() == moneyValue2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenValueNegative_ThrowException()
        {
            // Arrange
            Action action = () => new MoneyValue(-0.0001m);

            // Act and Assert
            action.Should().Throw<ArgumentException>().WithMessage("Value must not be less than zero.");
        }
    }
}
