using System;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class EmployeeId : IEquatable<EmployeeId>
    {
        public string Value { get; }

        public EmployeeId(string id)
        {
            id.EnsureNotNullOrWhitespace("Employee id value cannot be a null or empty string.");
            Value = id;
        }

        public bool Equals(EmployeeId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmployeeId) obj);
        }

        public static bool operator ==(EmployeeId first, EmployeeId second)
        {
            if (ReferenceEquals(first, second)) return true;
            if ((object)first == null) return false;
            if ((object)second == null) return false;

            return string.Compare(first.Value, second.Value, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool operator !=(EmployeeId first, EmployeeId second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .WithCaseInsensitiveString(Value)
                .Build()
                .Value;
        }

    }
}