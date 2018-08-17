using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class CommissionEmployee : SalaryEmployee
    {
        public CommissionRate Rate { get; }

        private CommissionEmployee(EmployeeId employeeId, Name name, Address address, CommissionRate rate, Money salary) : base(employeeId, name, address, salary)
        {
            rate.EnsureNotNull("Commission rate must not be null.");
            Rate = rate;
        }

        public static CommissionEmployee CreateNew(EmployeeId employeeId, Name name, Address address, CommissionRate rate,  Money salary)
        {
            return new CommissionEmployee(employeeId, name, address, rate, salary);
        }

        protected override bool CheckEquality(Employee other)
        {
            if (!base.CheckEquality(other)) return false;

            var employee = other as CommissionEmployee;

            if (employee == null) return false;

            return Rate == employee.Rate;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Employee> other)
        {
            var employee = other as CommissionEmployee;

            if (employee == null) return false;
            return CheckEquality(employee);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
           return HashCodeBuilder.CreateNew().Add(base.CalculateHashCode()).Add(Rate.GetHashCodeBuilder());
        }
    }
}