﻿using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class MoneyTests
    {
        [Fact]
        public void Monies_AreEqual()
        {
            // Arrange
            var m1 = new Money(new FakeCurrency(), 100m);
            var m2 = new Money(new FakeCurrency(), 100m);

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Monies_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var m1 = new Money(new FakeCurrency(), 100m);
            var m2 = new Money(new FakeCurrency(), 100m);

            // Act
            var hashCodesEqual = (m1.GetHashCode() == m2.GetHashCode());

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new [] {"different", "100"}, new [] {"usd", "100"})]
        [InlineData(new [] {"usd", "100.001"}, new [] {"usd", "100"})]
        public void Monies_WhenAllAttributesNotEqual_AreNotEqual(string[] money1Values, string[] money2Values)
        {
            //Arrange
            var m1 = new Money(new FakeCurrency(money1Values[0]), Convert.ToDecimal(money1Values[1]));
            var m2 = new Money(new FakeCurrency(money2Values[0]), Convert.ToDecimal(money2Values[1]));

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Theory]
        [InlineData(new[] { "different", "100" }, new[] { "usd", "100" })]
        [InlineData(new[] { "usd", "100.001" }, new[] { "usd", "100" })]
        public void Monies_WhenAllAttributesNotEqual_HaveDifferentHashCodes(string[] money1Values, string[] money2Values)
        {
            //Arrange
            var m1 = new Money(new FakeCurrency(money1Values[0]), Convert.ToDecimal(money1Values[1]));
            var m2 = new Money(new FakeCurrency(money2Values[0]), Convert.ToDecimal(money2Values[1]));

            // Act
            var hashCodesEqual = m1.GetHashCode() == m2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }
}
