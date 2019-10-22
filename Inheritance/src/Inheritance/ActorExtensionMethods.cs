using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public class ActorExtensionMethods
    {
        public string Speak(string castMem, bool womenPresent)
        {
            Penny penny=new Penny();
            Raj raj=new Raj();
            Sheldon sheldon=new Sheldon();

            string wordsSpoken="";

            switch (castMem)
            {
                case "Raj":
                    if (womenPresent)
                        wordsSpoken = raj.Speak();
                    else
                        wordsSpoken = raj.SpeakWomenPresent();
                    break;
                case "Sheldon":
                    wordsSpoken = sheldon.Speak();
                    break;
                case "Penny":
                    wordsSpoken = penny.Speak();
                    break;

            }

            return wordsSpoken;
        }
    }
}
