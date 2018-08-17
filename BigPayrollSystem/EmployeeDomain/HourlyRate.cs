using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class HourlyRate : DomainObject<HourlyRate>
    {
        public HourlyRateValue RateValue { get; }

        public HourlyRate(HourlyRateValue hourlyRateValue)
        {
            hourlyRateValue.EnsureNotNull("Hourly rate value must not be null.");
            RateValue = hourlyRateValue;
        }

        protected override bool CheckEquality(HourlyRate other)
        {
            return RateValue == other.RateValue;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<HourlyRate> other)
        {
            return CheckEquality((HourlyRate) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().Add(RateValue.GetHashCodeBuilder());
        }
    }
}