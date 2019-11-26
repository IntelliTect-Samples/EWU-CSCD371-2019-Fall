using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get; set; }
        public string EmailAddress { get; set; }

        public Person(string csvRow)
        {
            if (csvRow is null)
                throw new ArgumentNullException(nameof(csvRow));
            string[] data = csvRow.Split(',');
            FirstName = data[(int)SampleData.Column.FirstName];
            LastName = data[(int)SampleData.Column.LastName];
            EmailAddress = data[(int)SampleData.Column.Email];
            Address = new Address(csvRow);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   FirstName.Equals(person.FirstName) &&
                   LastName.Equals(person.LastName) &&
                   Address.Equals(person.Address) &&
                   EmailAddress.Equals(person.EmailAddress);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName, Address, EmailAddress).GetHashCode();
        }
    }
}