namespace SampleApp.Tests
{
    // MMM Comment: I like the fact that you have this class.  A tuple would have be an acceptable approach as well.
    public class Setting
    {
        public string Name { get; }
        public string Value { get; }

        public Setting(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}