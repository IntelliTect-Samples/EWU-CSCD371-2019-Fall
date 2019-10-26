﻿namespace Configuration
{
    public interface IConfig
    {
        public bool GetConfigValue(string name, string? value);

        public bool SetConfigValue(string name, string? value);
    }
}
