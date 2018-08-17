using System;
using BigCorp.EmployeeDomain;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class AddressTests
    {
        [Fact]
        public void WhenCareOfNotSpecified_ThrowException()
        {
            string careOf = null;
            var line1 = "foo";
            var city = "bar";
            var country = "see";

            Action action = () => new FakeAddress(careOf, line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("Care of must not be null or an empty string.");
        }

        [Fact]
        public void WhenLine1NotSpecified_ThrowException()
        {
            var careOf = "bah";
            string line1 = null;
            var city = "bar";
            var country = "see";

            Action action = () => new FakeAddress(careOf, line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("Line1 must not be null or an empty string.");
        }

        [Fact]
        public void WhenCityNotSpecified_ThrowException()
        {
            var careOf = "bah";
            var line1 = "boo";
            string city = null;
            var country = "see";

            Action action = () => new FakeAddress(careOf, line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("City must not be null or an empty string.");
        }

        [Fact]
        public void WhenCountryNotSpecified_ThrowException()
        {
            var careOf = "bah";
            var line1 = "boo";
            var city = "foo";
            string country = null;

            Action action = () => new FakeAddress(careOf, line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("Country must not be null or an empty string.");
        }

    }

    public class FakeAddress : Address
    {
        public FakeAddress() : this("careOf", "line1", "city", "country")
        {
            
        }

        public FakeAddress(string careOf, string line1, string city, string country) : base(careOf, line1, city, country)
        {
        }
    }
}
