using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class CommissionRateValue : DomainObject<CommissionRateValue>
    {
        public decimal Value { get; }

        public CommissionRateValue(decimal value)
        {
            value.EnsureWithinRangeInclusive(0.01m, 1m, "Commission rate must be between 0.01 and 1 inclusive.");
            Value = value;
        }

        protected override bool CheckEquality(CommissionRateValue other)
        {
            return Value == other.Value;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<CommissionRateValue> other)
        {
            return CheckEquality((CommissionRateValue) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().WithDecimal(Value);
        }
    }
}