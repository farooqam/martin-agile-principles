using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class UnitedStatesAddressTests
    {
        [Fact]
        public void Addresses_AreEqual()
        {
            // Arrange
            var address1 = new UnitedStatesAddress(new FakeName(), "bar", "qux", "baz", "boo", "hee", "haw");
            var address2 = new UnitedStatesAddress(new FakeName(), "bar", "qux", "baz", "boo", "hee", "haw");

            // Act
            var areEqual = address1 == address2;

            // Arrange
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Addresses_WhenEqual_HaveTheSameHashCode()
        {
            // Arrange
            var address1 = new UnitedStatesAddress(new FakeName(), "bar", "qux", "baz", "boo", "hee", "haw");
            var address2 = new UnitedStatesAddress(new FakeName(), "bar", "qux", "baz", "boo", "hee", "haw");

            // Act
            var hashCodesAreEqual = (address1.GetHashCode() == address2.GetHashCode());

            // Arrange
            hashCodesAreEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new[] { "FOO", "bar", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "BAR", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "QUX", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "BAZ", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "BOO", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        public void Addresses_WhenAttributesOnlyDifferByCase_AreEqual(string[] address1Values, string[] address2Values)
        {
            // Arrange
            var address1 = new UnitedStatesAddress(new FakeName(address1Values[0]), address1Values[1], address1Values[2], address1Values[3], address1Values[4], address1Values[5], address1Values[6]);
            var address2 = new UnitedStatesAddress(new FakeName(address2Values[0]), address2Values[1], address2Values[2], address2Values[3], address2Values[4], address2Values[5], address2Values[6]);

            // Act
            var areEqual = address1 == address2;

            // Arrange
            areEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new[] { "different", "bar", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "different", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "different", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "different", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "different", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "boo", "different", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "boo", "hee", "different" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]

        public void Addresses_WhenAllAttributesNotEqual_AreNotEqual(string[] address1Values, string[] address2Values)
        {
            // Arrange
            var address1 = new UnitedStatesAddress(new FakeName(address1Values[0]), address1Values[1], address1Values[2], address1Values[3], address1Values[4], address1Values[5], address1Values[6]);
            var address2 = new UnitedStatesAddress(new FakeName(address2Values[0]), address2Values[1], address2Values[2], address2Values[3], address2Values[4], address2Values[5], address2Values[6]);

            // Act
            var areEqual = address1 == address2;

            // Arrange
            areEqual.Should().BeFalse();
        }

        [Theory]
        [InlineData(new[] { "different", "bar", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "different", "qux", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "different", "baz", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "different", "boo", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "different", "hee", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "boo", "different", "haw" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "boo", "hee", "different" }, new[] { "foo", "bar", "qux", "baz", "boo", "hee", "haw" })]

        public void Addresses_WhenAllAttributesNotEqual_HaveDifferentHashCodes(string[] address1Values, string[] address2Values)
        {
            // Arrange
            var address1 = new UnitedStatesAddress(new FakeName(address1Values[0]), address1Values[1], address1Values[2], address1Values[3], address1Values[4], address1Values[5], address1Values[6]);
            var address2 = new UnitedStatesAddress(new FakeName(address2Values[0]), address2Values[1], address2Values[2], address2Values[3], address2Values[4], address2Values[5], address2Values[6]);

            // Act
            var hashCodesAreEqual = (address1.GetHashCode() == address2.GetHashCode());

            // Arrange
            hashCodesAreEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenStateNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => new UnitedStatesAddress(new FakeName(), "l1", "l2", "city", null, "country", "pc");

            // Act and Assert
            action.Should().Throw<ArgumentException>().WithMessage("State must not be null or an empty string.");
        }

        [Fact]
        public void WhenPostalCodeNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => new UnitedStatesAddress(new FakeName(), "l1", "l2", "city", "state", "country", null);

            // Act and Assert
            action.Should().Throw<ArgumentException>().WithMessage("Postal code must not be null or an empty string.");
        }
    }
}
