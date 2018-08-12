using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public abstract class Currency : DomainObject<Currency>
    {
        public string Abbreviation { get; }

        protected Currency(string abbreviation)
        {
            Abbreviation = abbreviation;
        }
        protected override bool CheckEquality(Currency other)
        {
            return Abbreviation.AreEqualDespiteCase(other.Abbreviation);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Currency> other)
        {
            return CheckEquality((Currency) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .WithCaseInsensitiveString(Abbreviation)
                .Build();
        }
    }

    public class UnitedStatesCurrency : Currency
    {
        public UnitedStatesCurrency() : base("USD")
        {
        }
    }
}
