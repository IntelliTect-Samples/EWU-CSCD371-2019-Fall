﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Configuration
{
    public interface IConfig
    {
        bool GetConfigValue(string name, out string? value);

        bool SetConfigValue(string name, string? value);
    }
}
