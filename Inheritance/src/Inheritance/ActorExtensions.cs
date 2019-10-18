namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string SayLine(this Actor actor) =>
            actor switch
        {
            Sheldon sheldon => $"{actor.GetType().Name}: { sheldon.Script}",
            Penny penny => $"{actor.GetType().Name}: { penny.Script}",
            Raj raj when raj.AreWomenPresent => $"{actor.GetType().Name}: {raj.Script}",
            Raj raj when !raj.AreWomenPresent => $"{actor.GetType().Name}: {raj.Script}",
            { } => string.Empty
        };
    }
}
