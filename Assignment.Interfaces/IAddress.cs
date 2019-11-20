namespace Assignment
{
    public interface IAddress
    {
        string StreetAddress { get; }
        string City { get; }
        string State { get; }
        string Zip { get; }
    }
}