using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class HourlyRateValue : DomainObject<HourlyRateValue>
    {
        public decimal Value { get; }

        public HourlyRateValue(decimal value)
        {
            value.EnsureNotNegative("Hourly rate value must be greater than zero.");
            Value = value;
        }

        protected override bool CheckEquality(HourlyRateValue other)
        {
            return Value == other.Value;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<HourlyRateValue> other)
        {
            return CheckEquality((HourlyRateValue) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().WithDecimal(Value);
        }
    }
}