﻿using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class UnitedStatesCurrencyTests
    {
        [Fact]
        public void Currencies_AreEqual()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new UnitedStatesCurrency();

            // Act
            var areEqual = currency1 == currency2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Currencies_WhenDifferingByCase_AreEqual()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new FakeCurrency("usd");

            // Act
            var areEqual = currency1 == currency2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Currencies_HaveSameHashCode()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new UnitedStatesCurrency();

            // Act
            var hashCodesAreEqual = (currency1.GetHashCode() == currency2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeTrue();
        }

        [Fact]
        public void Currencies_WhenDifferingByCase_HaveSameHashCode()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new FakeCurrency("usd");

            // Act
            var hashCodesAreEqual = (currency1.GetHashCode() == currency2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeTrue();
        }

        [Fact]
        public void Currencies_AreNotEqual()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new FakeCurrency("foo");

            // Act
            var areEqual = currency1 == currency2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Currencies_WhenNotEqual_HaveDifferentHashCodes()
        {
            // Arrange
            var currency1 = new UnitedStatesCurrency();
            var currency2 = new FakeCurrency("foo");

            // Act
            var hashCodesAreEqual = (currency1.GetHashCode() == currency2.GetHashCode());

            // Assert
            hashCodesAreEqual.Should().BeFalse();
        }
    }

    public class FakeCurrency : Currency
    {
        public FakeCurrency() : base("FAKE")
        {
            
        }

        public FakeCurrency(string abbreviation) : base(abbreviation)
        {
        }
    }
}