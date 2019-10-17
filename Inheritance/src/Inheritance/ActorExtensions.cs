using System;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static void Speak(this Actor actor, bool WomenArePresent)
        {
            string actorName = actor.GetType().ToString();
            switch (actorName)
            {
                case ("Raj"):
                    //DO SOMETHING
                    break;
                default:
                    //Do Something else
                    break;
            }
            if (actor.GetType() == typeof(Raj))
            {
                Raj temp = new Raj();
                if (WomenArePresent)
                {
                    temp.SpeakWithWomenPresent();
                } else
                {
                    temp.SpeakWithoutWomenPresent();
                }
            } else if (actor.GetType() == typeof(Penny))
            {
                Penny temp = new Penny();
                temp.Speak();
            } else
            {
                Sheldon temp = new Sheldon();
                temp.Speak();
            }
        }
    }
}