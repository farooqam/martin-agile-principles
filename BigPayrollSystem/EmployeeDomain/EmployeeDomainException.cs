using System;
using System.Runtime.Serialization;

namespace BigCorp.EmployeeDomain
{
    [Serializable]
    public class EmployeeDomainException : Exception
    {
        public EmployeeDomainException()
        {
        }

        public EmployeeDomainException(string message) : base(message)
        {
        }

        public EmployeeDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EmployeeDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}