using System;
namespace Inheritance
{
    public static class ExtensionClass
    {
        public static string Speak(this Actor actor) =>
            actor switch
            {
                Penny p => p.Phrase(),
                Sheldon s => s.Phrase(),
                Raj { WomenArePresent: false } => Raj.Phrase(),
                Raj { WomenArePresent: true } => Raj.Mumble(),
                { } => throw new ArgumentException("Not a known actor", nameof(actor)),
                null => throw new ArgumentNullException(nameof(actor))
            };


    }
}
