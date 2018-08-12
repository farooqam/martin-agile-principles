namespace BigCorp.EmployeeDomain
{
    public abstract class Address
    {
        public string CareOf { get; }
        public string Line1 { get; }
        public string City { get; }
        public string Country { get; }

        protected Address(string careOf, string line1, string city, string country)
        {
            CareOf = careOf;
            Line1 = line1;
            City = city;
            Country = country;
        }
    }
}