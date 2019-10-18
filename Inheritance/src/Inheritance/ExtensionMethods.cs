namespace Inheritance
{
    public static class ExtensionMethods
    {
        public static string Speak(this Actor actor, bool womenPresent)
        {
            switch (actor)
            {
                case Sheldon s:
                    return s.Words;

                case Penny p:
                    return p.Words;

                case Raj r:
                    if (womenPresent)
                        return "mumble";
                    return r.Words;
            }
            return "No actors";
        }
    }
}