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
        private SalariedEmployee(EmployeeId employeeId, Name name, UnitedStatesAddress address) : base(employeeId, name, address)
        {
        }

        public static SalariedEmployee CreateNew(EmployeeId employeeId, Name name, UnitedStatesAddress address)
        {
            return new SalariedEmployee(employeeId, name, address);
        }
    }
}
