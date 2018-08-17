namespace BigCorp.EmployeeDomain
{
    public class SalaryEmployee : Employee
    {
        public Money Salary { get; }

        protected SalaryEmployee(EmployeeId employeeId, Name name, Address address, Money salary) : base(employeeId, name, address)
        {
            salary.EnsureNotNull("Employee salary must not be null.");

            Salary = salary;
        }

        public static SalaryEmployee CreateNew(EmployeeId employeeId, Name name, Address address, Money salary)
        {
            return new SalaryEmployee(employeeId, name, address, salary);
        }
    }
}