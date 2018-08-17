using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class CommissionRate : DomainObject<CommissionRate>
    {
        public CommissionRateValue Value { get; }

        public CommissionRate(CommissionRateValue value)
        {
            value.EnsureNotNull("Commission rate value must not be null.");
            Value = value;
        }

        protected override bool CheckEquality(CommissionRate other)
        {
            return Value == other.Value;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<CommissionRate> other)
        {
            return CheckEquality((CommissionRate) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().Add(Value.GetHashCodeBuilder());
        }
    }
}