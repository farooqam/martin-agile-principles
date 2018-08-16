using BigCorp.Utility;

namespace BigCorp.EmployeeDomain
{
    public class Name : DomainObject<Name>
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string Suffix { get; }
        public string Title { get; }

        public Name(string firstName, string middleName, string lastName, string suffix, string title)
        {
            firstName.EnsureNotNullOrWhitespace("First name must not be null or an empty string.");
            lastName.EnsureNotNullOrWhitespace("Last name must not be null or an empty string.");

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            Title = title;
        }

        protected override bool CheckEquality(Name other)
        {
            return FirstName.AreEqualDespiteCase(other.FirstName) &&
                   LastName.AreEqualDespiteCase(other.LastName) &&
                   MiddleName.AreEqualDespiteCase(other.MiddleName) &&
                   Suffix.AreEqualDespiteCase(other.Suffix) &&
                   Title.AreEqualDespiteCase(other.Title);
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<Name> other)
        {
            var name = (Name) other;
            return CheckEquality(name);
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            return HashCodeBuilder.CreateNew()
                .WithCaseInsensitiveString(FirstName)
                .WithCaseInsensitiveString(MiddleName)
                .WithCaseInsensitiveString(LastName)
                .WithCaseInsensitiveString(Suffix)
                .WithCaseInsensitiveString(Title)
                .Build();
        }
    }
}