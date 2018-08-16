using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class MoneyValue : DomainObject<MoneyValue>
    {
        public decimal Value { get; }

        public MoneyValue(decimal value)
        {
            value.EnsureNotNegative("Value must not be less than zero.");

            Value = value;
        }
        protected override bool CheckEquality(MoneyValue other)
        {
            return Value == other.Value;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<MoneyValue> other)
        {
            return CheckEquality((MoneyValue) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().WithDecimal(Value);
        }
    }
}