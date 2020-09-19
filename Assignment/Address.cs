namespace Assignment
{
    public class Address : IAddress
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address(string streetAddress, string city, string state, string zip)
        {
            if (string.IsNullOrWhiteSpace(streetAddress))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(streetAddress));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(city));
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(state));
            }

            if (string.IsNullOrWhiteSpace(zip))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(zip));
            }

            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
