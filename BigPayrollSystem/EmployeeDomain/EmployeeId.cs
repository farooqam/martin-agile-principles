using System;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class EmployeeId : DomainObject<EmployeeId>
    {
        public string Value { get; }

        public EmployeeId(string id)
        {
            id.EnsureNotNullOrWhitespace("Employee id must not be null or an empty string.");
            Value = id;
        }

        protected override bool CheckEquality(EmployeeId other)
        {
            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<EmployeeId> other)
        {
            return string.Compare(this.Value, ((EmployeeId) other).Value, StringComparison.OrdinalIgnoreCase) == 0;
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .WithCaseInsensitiveString(Value)
                .Build();
        }
    }
}