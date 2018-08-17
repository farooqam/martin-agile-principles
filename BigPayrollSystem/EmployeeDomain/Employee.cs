using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public abstract class Employee : DomainObject<Employee>
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

        protected override bool CheckEquality(Employee other)
        {
            return EmployeeId == other.EmployeeId &&
                   Name == other.Name &&
                   Address == other.Address;
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Employee> other)
        {
            return CheckEquality((Employee) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder
                .CreateNew()
                .Add(EmployeeId.GetHashCodeBuilder())
                .Add(Name.GetHashCodeBuilder())
                .Add(Address.GetHashCodeBuilder());
        }
    }
}
