namespace Configuration
{
    public class EnvironmentConfig : Config
    {
        public override bool GetConfigValue(string name, out string? value)
        {
            value = null;
            return true;
        }

        public override bool SetConfigValue(string name, string? value)
        {
            return true;
        }
    }
}
            
