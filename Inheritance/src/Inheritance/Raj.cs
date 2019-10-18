namespace Inheritance
{
    public class Raj : Actor
    {
        public string Script 
        {
            get 
            {
                return AreWomenPresent ? "mumble" : "I am afraid of women";
            }
        }
        public bool AreWomenPresent { get; set; }
    }
}
