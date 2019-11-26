namespace Assignment {
    public class Person : IPerson {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }

        IAddress IPerson.Address => Address;
    }
}
