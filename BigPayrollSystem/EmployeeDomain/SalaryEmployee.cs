using BigCorp.Utility;

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

        protected override bool CheckEquality(Employee other)
        {
            if (!base.CheckEquality(other)) return false;

            var employee = other as SalaryEmployee;

            if (employee == null) return false;

            return Salary == employee.Salary;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Employee> other)
        {
            var employee = other as SalaryEmployee;

            if (employee == null) return false;
            return CheckEquality(employee);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew().Add(base.CalculateHashCode()).Add(Salary.GetHashCodeBuilder());
        }
    }
}