using System;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public abstract class DomainObject<TType> : IEquatable<TType> where TType: class
    {
        protected abstract bool CheckEquality(TType other);
        protected abstract bool CheckEqualityUsingOperator(DomainObject<TType> other);
        protected abstract HashCodeBuilder CalculateHashCode();
        
        public bool Equals(TType other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CheckEquality(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is TType)) return false;
            return Equals((TType)obj);
        }

        public override int GetHashCode()
        {
            return CalculateHashCode().Value;
        }

        public static bool operator ==(DomainObject<TType> first, DomainObject<TType> second)
        {
            if (ReferenceEquals(first, second)) return true;
            if ((object)first == null) return false;
            if ((object)second == null) return false;

            return first.CheckEqualityUsingOperator(second);
        }

        public static bool operator !=(DomainObject<TType> first, DomainObject<TType> second)
        {
            return !(first == second);
        }

    }
}
