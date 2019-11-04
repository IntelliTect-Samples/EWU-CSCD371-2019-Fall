using Newtonsoft.Json;

namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, (int x, int y) location, Person owner)
        {
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            string theSize = Size.ToString();
            if (Size == 0)
                return "";
            else if ((int)Size > 4)
                theSize = $"{Size - 4} Premium";
            return $"Size: {theSize}, Location: {Location.x} {Location.y}, Owner: {Owner.ToString()}";
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}