using System;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class Name : IEquatable<Name>
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string Suffix { get; }
        public string Title { get; }

        public Name(string firstName, string middleName, string lastName, string suffix, string title)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            Title = title;
        }

        public bool Equals(Name other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return FirstName.AreEqualDespiteCase(other.FirstName) &&
                   LastName.AreEqualDespiteCase(other.LastName) &&
                   MiddleName.AreEqualDespiteCase(other.MiddleName) &&
                   Suffix.AreEqualDespiteCase(other.Suffix) &&
                   Title.AreEqualDespiteCase(other.Title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Name)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 385229220;
            hashCode = hashCode * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(Suffix);
            hashCode = hashCode * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(Title);
            return hashCode;
        }

        public static bool operator ==(Name first, Name second)
        {
            if (ReferenceEquals(first, second)) return true;
            if ((object)first == null) return false;
            if ((object)second == null) return false;

            return first.FirstName.AreEqualDespiteCase(second.FirstName) &&
                   first.LastName.AreEqualDespiteCase(second.LastName) &&
                   first.MiddleName.AreEqualDespiteCase(second.MiddleName) &&
                   first.Suffix.AreEqualDespiteCase(second.Suffix) &&
                   first.Title.AreEqualDespiteCase(second.Title);
        }

        public static bool operator !=(Name first, Name second)
        {
            return !(first == second);
        }
    }
}