﻿using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public abstract class Address : DomainObject<Address>
    {
        public Name CareOf { get; }
        public string Line1 { get; }
        public string City { get; }
        public string Country { get; }

        protected Address(Name careOf, string line1, string city, string country)
        {
            careOf.EnsureNotNull("Care of must not be null.");
            line1.EnsureNotNullOrWhitespace("Line1 must not be null or an empty string.");
            city.EnsureNotNullOrWhitespace("City must not be null or an empty string.");
            country.EnsureNotNullOrWhitespace("Country must not be null or an empty string.");

            CareOf = careOf;
            Line1 = line1;
            City = city;
            Country = country;
        }

        protected override bool CheckEquality(Address other)
        {
            return CareOf == other.CareOf &&
                   Line1.AreEqualDespiteCase(other.Line1) &&
                   City.AreEqualDespiteCase(other.City) &&
                   Country.AreEqualDespiteCase(other.Country);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Address> other)
        {
            return CheckEquality((Address)other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .Add(CareOf.GetHashCodeBuilder())
                .WithCaseInsensitiveString(Line1)
                .WithCaseInsensitiveString(City)
                .WithCaseInsensitiveString(Country)
                .Build();
        }
    }
}