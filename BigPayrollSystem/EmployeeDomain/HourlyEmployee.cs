using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class HourlyEmployee : Employee
    {
        public HourlyRate Rate { get; }

        private HourlyEmployee(EmployeeId employeeId, Name name, Address address, HourlyRate rate) : base(employeeId, name, address)
        {
            rate.EnsureNotNull("Hourly rate must not be null.");
            Rate = rate;
        }

        public static HourlyEmployee CreateNew(EmployeeId employeeId, Name name, Address address, HourlyRate rate)
        {
            return new HourlyEmployee(employeeId, name, address, rate);
        }

        protected override bool CheckEquality(Employee other)
        {
            if (!base.CheckEquality(other)) return false;

            var employee = other as HourlyEmployee;
            if (employee == null) return false;

            return Rate == employee.Rate;

        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Employee> other)
        {
            var employee = other as HourlyEmployee;

            if (employee == null) return false;
            return CheckEquality(employee);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().Add(base.CalculateHashCode()).Add(Rate.GetHashCodeBuilder());
        }
    }
}