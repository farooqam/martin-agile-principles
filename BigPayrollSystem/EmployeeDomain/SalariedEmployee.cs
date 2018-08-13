namespace BigCorp.EmployeeDomain
{
    public sealed class SalariedEmployee : Employee
    {
        public Money Salary { get; }

        private SalariedEmployee(EmployeeId employeeId, Name name, UnitedStatesAddress address, Money salary) : base(employeeId, name, address)
        {
            salary.EnsureNotNull("Employee salary must not be null.");

            Salary = salary;
        }

        public static SalariedEmployee CreateNew(EmployeeId employeeId, Name name, UnitedStatesAddress address, Money salary)
        {
            return new SalariedEmployee(employeeId, name, address, salary);
        }
    }
}