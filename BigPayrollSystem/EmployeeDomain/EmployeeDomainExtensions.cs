using System;

namespace BigCorp.EmployeeDomain
{
    public static class EmployeeDomainExtensions
    {
        public static void EnsureNotNull<TType>(this DomainObject<TType> domainObject, string messageWhenNotEnsured) where TType : class 
        {
            if(domainObject == null) throw new ArgumentException(messageWhenNotEnsured);
        }
    }
}
