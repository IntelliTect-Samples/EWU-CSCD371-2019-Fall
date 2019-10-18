using System;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static void Speak(this Actor actor, bool WomenArePresent)
        {
            string text;
            //switch (actorName)
            //{
            //    case ("Raj"):
            //        //DO SOMETHING
            //        break;
            //    default:
            //        //Do Something else
            //        break;
            //}
            //if (actor.GetType() == typeof(Raj))
            //{
            //    Raj temp = new Raj();
            //    if (WomenArePresent)
            //    {
            //        temp.SpeakWithWomenPresent();
            //    } else
            //    {
            //        temp.SpeakWithoutWomenPresent();
            //    }
            //} else if (actor.GetType() == typeof(Penny))
            //{
            //    Penny temp = new Penny();
            //    temp.Speak();
            //} else
            //{
            //    Sheldon temp = new Sheldon();
            //    temp.Speak();
            //}

            text = (actor switch
            {
                Penny penny => text = (new Penny().Speak()),
                Sheldon sheldon => text = (new Sheldon().Speak()),
                Raj raj when (WomenArePresent) => text = (new Raj().SpeakWithWomenPresent()),
                Raj raj when (!WomenArePresent) => text = (new Raj().SpeakWithoutWomenPresent()),
                { } => throw new NotSupportedException(),
                null => throw new NullReferenceException(),
            });
        }
    }
}