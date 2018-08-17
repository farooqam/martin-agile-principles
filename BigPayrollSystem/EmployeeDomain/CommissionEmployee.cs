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
    }
}