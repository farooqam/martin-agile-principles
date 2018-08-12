using System;

namespace BigCorp.Utility
{
    public static class EmployeeDomainExtensions
    {
        public static void EnsureNotNullOrWhitespace(this string s, string messageWhenNotEnsured)
        {
            if(string.IsNullOrWhiteSpace(s)) throw new ArgumentException(messageWhenNotEnsured);
        }

        public static bool AreEqualDespiteCase(this string s, string other)
        {
            return string.Compare(s, other, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
