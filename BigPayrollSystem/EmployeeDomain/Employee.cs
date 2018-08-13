namespace BigCorp.EmployeeDomain
{
    public abstract class Employee
    {
        public EmployeeId EmployeeId { get; }
        public Name Name { get; }
        public UnitedStatesAddress Address { get; }

        protected Employee(EmployeeId employeeId, Name name, UnitedStatesAddress address)
        {
            EmployeeId = employeeId;
            Name = name;
            Address = address;
        }
    }

    public sealed class SalariedEmployee : Employee
    {
        public Money Salary { get; }

        private SalariedEmployee(EmployeeId employeeId, Name name, UnitedStatesAddress address, Money salary) : base(employeeId, name, address)
        {
            Salary = salary;
        }

        public static SalariedEmployee CreateNew(EmployeeId employeeId, Name name, UnitedStatesAddress address, Money salary)
        {
            return new SalariedEmployee(employeeId, name, address, salary);
        }
    }
}
