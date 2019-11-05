using Newtonsoft.Json;
using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Sizes size, (int x, int y) location, Person owner)
        {
            if (size == (Sizes.Small | Sizes.Medium) ||
                size == (Sizes.Small | Sizes.Large) ||
                size == (Sizes.Medium | Sizes.Small) ||
                size == (Sizes.Medium | Sizes.Large) ||
                size == (Sizes.Large | Sizes.Small) ||
                size == (Sizes.Large | Sizes.Medium))
            {
                throw new ArgumentException(nameof(size));
            }

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