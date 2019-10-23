namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = null;
            return true;
        }

        public bool SetConfigValue(string name, string value)
        {
            return true;
        }
    }
}
            
