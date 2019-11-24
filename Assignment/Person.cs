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
            string[] data = csvRow.Split(',');
            FirstName = data[(int)SampleData.Information.FirstName];
            LastName = data[(int)SampleData.Information.LastName];
            EmailAddress = data[(int)SampleData.Information.Email];
            Address = new Address(csvRow);
        }
    }
}