using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            //Configuration.config.Default.Setting;
            if(name is null || name.Length < 1 || name.Contains(" ") || name.Contains("="))
            {
                value = null;
                return false;
            }
            config ccd = Configuration.config.Default;
            if(ccd[name] is null)
            {
                value = null;
                return false;
            }
            value = (string) ccd[name];
            return true;


        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null || name.Length < 1 || name.Contains(" ") || name.Contains("="))
            {
                value = null;
                return false;
            }
            config ccd = Configuration.config.Default;
            SettingsProperty sp = new SettingsProperty(name);
            sp.DefaultValue = "Default";
            sp.IsReadOnly = false;
            sp.PropertyType = typeof(string);
            sp.Provider = ccd.Providers["LocalFileSettingsProvider"];
            sp.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
            ccd.Properties.Add(sp);
            ccd[name] = value;
            return true;
        }
    }
}
