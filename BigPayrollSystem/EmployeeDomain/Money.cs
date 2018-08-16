using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class Money : DomainObject<Money>
    {
        public Currency Currency { get; }
        public MoneyValue Value { get; }

        public Money(Currency currency, MoneyValue value)
        {
            Currency = currency;
            Value = value;
        }

        protected override bool CheckEquality(Money other)
        {
            return (Currency == other.Currency) && (Value == other.Value);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Money> other)
        {
            return CheckEquality((Money) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return Currency.GetHashCodeBuilder().Add(Value.GetHashCodeBuilder());
        }
    }
}
