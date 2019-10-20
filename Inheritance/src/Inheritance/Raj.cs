using System;
namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public static string Mumble() => "Mumble mumble";

        public static string Phrase() => "My name is Raj";
    }
}
