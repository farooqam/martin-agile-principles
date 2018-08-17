using System;
using BigCorp.Utility;
using FluentAssertions;
using Xunit;

namespace UtilityTests
{
    public class ExtensionsTests
    {
        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        public void EnsureNotNullOrWhitespace_WhenValueNullOrWhitespace_ThrowException(string value)
        {
            // Arrange
            Action action = () => value.EnsureNotNullOrWhitespace("blah");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("blah");

            
        }

        [Fact]
        public void EnsureNotNullOrWhitespace_WhenValueNotNullOrWhitespace_DoesNotThrowException()
        {
            // Arrange
            var value = "foo";
            Action action = () => value.EnsureNotNullOrWhitespace("blah");


            // Act & Assert
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void AreEqualDespiteCase_WhenStringsDifferOnlyByCase_ReturnsTrue()
        {
            // Arrange
            var s1 = "FOO";
            var s2 = "foo";

            // Act
            var result = s1.AreEqualDespiteCase(s2);

            // Assert
            result.Should().BeTrue();

        }

        [Fact]
        public void AreEqualDespiteCase_WhenStringsHaveDifferentContent_ReturnsFalse()
        {
            // Arrange
            var s1 = "bar";
            var s2 = "foo";

            // Act
            var result = s1.AreEqualDespiteCase(s2);

            // Assert
            result.Should().BeFalse();

        }

        [Theory]
        [InlineData(null, "foo")]
        [InlineData("foo", null)]
        [InlineData(" ", null)]
        [InlineData(null, " ")]
        public void AreEqualDespiteCase_ReturnsFalse(string s1, string s2)
        {
            // Act
            var result = s1.AreEqualDespiteCase(s2);

            // Assert
            result.Should().BeFalse();

        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(" ", " ")]
        public void AreEqualDespiteCase_ReturnsTrue(string s1, string s2)
        {
            // Act
            var result = s1.AreEqualDespiteCase(s2);

            // Assert
            result.Should().BeTrue();

        }

        [Fact]
        public void EnsureNotNegative_WhenValueNegative_ThrowException()
        {
            // Arrange
            decimal value = -1;
            Action action = () => value.EnsureNotNegative("foo");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("foo");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void EnsureNotNegative_WhenValueNotNegative_DoesNotThrow(decimal value)
        {
            // Arrange
            Action action = () => value.EnsureNotNegative("foo");

            // Act & Assert
            action.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(0, 10, -1)]
        [InlineData(0, 10, 11)]
        public void EnsureWithinRangeInclusive_ThrowException(decimal low, decimal high, decimal value)
        {
            // Arrange
            Action action = () => value.EnsureWithinRangeInclusive(low, high, "foo");

            // Act & Assert
            action.Should().Throw<ArgumentException>().WithMessage("foo");

            
        }

        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(0, 10, 10)]
        [InlineData(0, 10, 4)]
        public void EnsureWithinRangeInclusive_DoesNotThrowException(decimal low, decimal high, decimal value)
        {
            // Arrange
            Action action = () => value.EnsureWithinRangeInclusive(low, high, "foo");

            // Act & Assert
            action.Should().NotThrow<ArgumentException>();
        }
    }
}
