namespace SampleApp.Tests
{
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