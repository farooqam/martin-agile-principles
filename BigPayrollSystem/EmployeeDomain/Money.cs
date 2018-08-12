using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public sealed class Money : DomainObject<Money>
    {
        public Currency Currency { get; }
        public decimal Value { get; }

        public Money(Currency currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        protected override bool CheckEquality(Money other)
        {
            return (Currency == other.Currency) && (Value == other.Value);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Money> other)
        {
            return CheckEquality((Money) other);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return Currency.GetHashCode()
        }
    }
}
