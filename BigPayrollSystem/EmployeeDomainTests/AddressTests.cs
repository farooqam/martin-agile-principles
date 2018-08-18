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
            Name careOf = null;
            var line1 = "foo";
            var city = "bar";
            var country = "see";

            Action action = () => new FakeAddress(careOf, line1, city, country);
            action.Should().Throw<EmployeeDomainException>().WithMessage("Care of must not be null.");
        }

        [Fact]
        public void WhenLine1NotSpecified_ThrowException()
        {
            string line1 = null;
            var city = "bar";
            var country = "see";

            Action action = () => new FakeAddress(new FakeName(), line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("Line1 must not be null or an empty string.");
        }

        [Fact]
        public void WhenCityNotSpecified_ThrowException()
        {
            var line1 = "boo";
            string city = null;
            var country = "see";

            Action action = () => new FakeAddress(new FakeName(), line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("City must not be null or an empty string.");
        }

        [Fact]
        public void WhenCountryNotSpecified_ThrowException()
        {
            var line1 = "boo";
            var city = "foo";
            string country = null;

            Action action = () => new FakeAddress(new FakeName(), line1, city, country);
            action.Should().Throw<ArgumentException>().WithMessage("Country must not be null or an empty string.");
        }

    }

    public class FakeAddress : Address
    {
        public FakeAddress() : this(new FakeName(), "line1", "city", "country")
        {
            
        }

        public FakeAddress(Name careOf, string line1, string city, string country) : base(careOf, line1, city, country)
        {
        }
    }

    public class FakeName : Name
    {
        public FakeName() : this("first", null, "last", null, null)
        {
            
        }

        public FakeName(string firstName) : this(firstName, null, "last", null, null)
        {
            
        }

        public FakeName(string firstName, string middleName, string lastName, string suffix, string title) 
            : base(firstName, middleName, lastName, suffix, title)
        {
        }
    }
}
