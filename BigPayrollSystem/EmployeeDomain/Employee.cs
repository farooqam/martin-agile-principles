namespace BigCorp.EmployeeDomain
{
    public abstract class Employee
    {
        public EmployeeId EmployeeId { get; }
        public Name Name { get; }
        public Address Address { get; }

        protected Employee(EmployeeId employeeId, Name name, Address address)
        {
            employeeId.EnsureNotNull("Employee id must not be null.");
            name.EnsureNotNull("Employee name must not be null.");
            address.EnsureNotNull("Employee address must not be null.");

            EmployeeId = employeeId;
            Name = name;
            Address = address;
        }
    }
}
