using System;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class UnitedStatesAddress : Address
    {
        public string Line2 { get;  }
        public string State { get;  }
        public string PostalCode { get;  }

        public UnitedStatesAddress(string careOf, string line1, string line2, string city, string state, string country, string postalCode)
            :base(careOf, line1, city, country)
        {
            Line2 = line2;
            State = state;
            PostalCode = postalCode;
        }

        protected override bool CheckEquality(Address other)
        {
            var address = (UnitedStatesAddress) other;

            return CareOf.AreEqualDespiteCase(address.CareOf) &&
                   Line1.AreEqualDespiteCase(address.Line1) &&
                   Line2.AreEqualDespiteCase(address.Line2) &&
                   City.AreEqualDespiteCase(address.City) &&
                   State.AreEqualDespiteCase(address.State) &&
                   Country.AreEqualDespiteCase(address.Country) &&
                   PostalCode.AreEqualDespiteCase(address.PostalCode);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Address> other)
        {
            return CheckEquality((UnitedStatesAddress)other);
        }

        protected override int CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .WithCaseInsensitiveString(CareOf)
                .WithCaseInsensitiveString(Line1)
                .WithCaseInsensitiveString(Line2)
                .WithCaseInsensitiveString(City)
                .WithCaseInsensitiveString(State)
                .WithCaseInsensitiveString(Country)
                .WithCaseInsensitiveString(PostalCode)
                .Build()
                .Value;
        }

        //public bool Equals(UnitedStatesAddress other)
        //{
        //    if (ReferenceEquals(null, other)) return false;
        //    if (ReferenceEquals(this, other)) return true;

        //    return CareOf.AreEqualDespiteCase(other.CareOf) &&
        //           Line1.AreEqualDespiteCase(other.Line1) &&
        //           Line2.AreEqualDespiteCase(other.Line2) &&
        //           City.AreEqualDespiteCase(other.City) &&
        //           State.AreEqualDespiteCase(other.State) &&
        //           Country.AreEqualDespiteCase(other.Country) &&
        //           PostalCode.AreEqualDespiteCase(other.PostalCode);
        //}

        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    if (ReferenceEquals(this, obj)) return true;
        //    if (obj.GetType() != GetType()) return false;
        //    return Equals((UnitedStatesAddress)obj);
        //}

        //public override int GetHashCode()
        //{
        //    return HashCodeBuilder.CreateNew()
        //        .WithCaseInsensitiveString(CareOf)
        //        .WithCaseInsensitiveString(Line1)
        //        .WithCaseInsensitiveString(Line2)
        //        .WithCaseInsensitiveString(City)
        //        .WithCaseInsensitiveString(State)
        //        .WithCaseInsensitiveString(Country)
        //        .WithCaseInsensitiveString(PostalCode)
        //        .Build()
        //        .Value;
        //}

        //public static bool operator ==(UnitedStatesAddress first, UnitedStatesAddress second)
        //{
        //    if (ReferenceEquals(first, second)) return true;
        //    if ((object)first == null) return false;
        //    if ((object)second == null) return false;

        //    return first.CareOf.AreEqualDespiteCase(second.CareOf) &&
        //           first.Line1.AreEqualDespiteCase(second.Line1) &&
        //           first.Line2.AreEqualDespiteCase(second.Line2) &&
        //           first.City.AreEqualDespiteCase(second.City) &&
        //           first.State.AreEqualDespiteCase(second.State) &&
        //           first.Country.AreEqualDespiteCase(second.Country) &&
        //           first.PostalCode.AreEqualDespiteCase(second.PostalCode);
        //}

        //public static bool operator !=(UnitedStatesAddress first, UnitedStatesAddress second)
        //{
        //    return !(first == second);
        //}
    }
}