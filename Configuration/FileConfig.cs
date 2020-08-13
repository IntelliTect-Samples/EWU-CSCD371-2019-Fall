using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class FileConfig : BaseConfig
    {

        private static string ConfigFile = "config.settings";

        public override bool GetConfigValue(string name, out string? value)
        {
            //read from file
            value = "";
            return true;//CHANGE
        }

        public override bool SetConfigValue(string name, string? value)
        {
            //write file
            return true;//CHANGE
        }
    }
}
