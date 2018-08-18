using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class UnitedStatesAddress : Address
    {
        public string Line2 { get;  }
        public string State { get;  }
        public string PostalCode { get;  }

        public UnitedStatesAddress(Name careOf, string line1, string line2, string city, string state, string country, string postalCode)
            :base(careOf, line1, city, country)
        {
            state.EnsureNotNullOrWhitespace("State must not be null or an empty string.");
            postalCode.EnsureNotNullOrWhitespace("Postal code must not be null or an empty string.");

            Line2 = line2;
            State = state;
            PostalCode = postalCode;
        }

        protected override bool CheckEquality(Address other)
        {
            var address = (UnitedStatesAddress) other;

            if (!base.CheckEquality(other)) return false;

            return Line2.AreEqualDespiteCase(address.Line2) &&
                   State.AreEqualDespiteCase(address.State) &&
                   PostalCode.AreEqualDespiteCase(address.PostalCode);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Address> other)
        {
            return CheckEquality((UnitedStatesAddress)other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return base.CalculateHashCode()
                .WithCaseInsensitiveString(Line2)
                .WithCaseInsensitiveString(State)
                .WithCaseInsensitiveString(PostalCode)
                .Build();
        }
    }
}