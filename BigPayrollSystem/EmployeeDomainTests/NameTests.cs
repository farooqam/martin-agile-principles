using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class NameTests
    {
        [Fact]
        public void Names_AreEqual()
        {
            // Arrange
            var name1 = new Name("foo", "bar", "qux", "baz", "boo");
            var name2 = new Name("foo", "bar", "qux", "baz", "boo");

            // Act
            var areEqual = name1 == name2;

            // Arrange
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Names_WhenEqual_HaveTheSameHashCode()
        {
            // Arrange
            var name1 = new Name("foo", "bar", "qux", "baz", "boo");
            var name2 = new Name("foo", "bar", "qux", "baz", "boo");

            // Act
            var hashCodesAreEqual = (name1.GetHashCode() == name2.GetHashCode());

            // Arrange
            hashCodesAreEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new[] { "FOO", "bar", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "BAR", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "QUX", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "BAZ", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "BOO" }, new[] { "foo", "bar", "qux", "baz", "boo" })]

        public void Names_WhenAttributesOnlyDifferByCase_AreEqual(string[] name1Values, string[] name2Values)
        {
            // Arrange
            var name1 = new Name(name1Values[0], name1Values[1], name1Values[2], name1Values[3], name1Values[4]);
            var name2 = new Name(name2Values[0], name2Values[1], name2Values[2], name2Values[3], name2Values[4]);

            // Act
            var areEqual = name1 == name2;

            // Arrange
            areEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new[] { "FOO", "bar", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "BAR", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "QUX", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "BAZ", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "BOO" }, new[] { "foo", "bar", "qux", "baz", "boo" })]

        public void Names_WhenAttributesOnlyDifferByCase_HaveTheSameHashCode(string[] name1Values, string[] name2Values)
        {
            // Arrange
            var name1 = new Name(name1Values[0], name1Values[1], name1Values[2], name1Values[3], name1Values[4]);
            var name2 = new Name(name2Values[0], name2Values[1], name2Values[2], name2Values[3], name2Values[4]);

            // Act
            var hashCodesAreEqual = (name1.GetHashCode() == name2.GetHashCode());

            // Arrange
            hashCodesAreEqual.Should().BeTrue();
        }

        [Theory]
        [InlineData(new[]  { "different", "bar", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[]  { "foo", "different", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[]  { "foo", "bar", "different", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[]  { "foo", "bar", "qux", "different", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[]  { "foo", "bar", "qux", "baz", "different" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        public void Names_WhenAllAttributesNotEqual_AreNotEqual(string[] name1Values, string[] name2Values)
        {
            // Arrange
            var name1 = new Name(name1Values[0], name1Values[1], name1Values[2], name1Values[3], name1Values[4]);
            var name2 = new Name(name2Values[0], name2Values[1], name2Values[2], name2Values[3], name2Values[4]);
            
            // Act
            var areEqual = name1 == name2;

            // Arrange
            areEqual.Should().BeFalse();
        }

        [Theory]
        [InlineData(new[] { "different", "bar", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "different", "qux", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "different", "baz", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "different", "boo" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        [InlineData(new[] { "foo", "bar", "qux", "baz", "different" }, new[] { "foo", "bar", "qux", "baz", "boo" })]
        public void Names_WhenAllAttributesNotEqual_HaveDifferentHashCodes(string[] name1Values, string[] name2Values)
        {
            // Arrange
            var name1 = new Name(name1Values[0], name1Values[1], name1Values[2], name1Values[3], name1Values[4]);
            var name2 = new Name(name2Values[0], name2Values[1], name2Values[2], name2Values[3], name2Values[4]);

            // Act
            var hashCodesAreEqual = (name1.GetHashCode() == name2.GetHashCode());

            // Arrange
            hashCodesAreEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenFirstNameNotSpecified_ThrowException()
        {
            // Arrange
            string firstName = null;
            var lastName = "foo";
            var middleName = "bag";
            var suffix = "boo";
            var title = "yay";

            Action action = () => new Name(firstName, middleName, lastName, suffix, title);

            //Act and Assert
            action.Should().Throw<ArgumentException>().WithMessage("First name must not be null or an empty string.");

        }

        [Fact]
        public void WhenLastNameNotSpecified_ThrowException()
        {
            // Arrange
            var firstName = "whu";
            string lastName = null;
            var middleName = "bag";
            var suffix = "boo";
            var title = "yay";

            Action action = () => new Name(firstName, middleName, lastName, suffix, title);

            //Act and Assert
            action.Should().Throw<ArgumentException>().WithMessage("Last name must not be null or an empty string.");

        }

    }
}
