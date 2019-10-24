using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            FileConfig fileConfig = new FileConfig("Config.settings");

            fileConfig.WriteConfig("PATH1","VALUE1");
            fileConfig.WriteConfig("PATH2", "VALUE2");
            fileConfig.WriteConfig("PATH3", "VALUE3");
            fileConfig.WriteConfig("PATH4", "VALUE4");
            fileConfig.WriteConfig("PATH5", "VALUE5");

            List<Tuple<string, string?>> configList = fileConfig.ReadConfig();

            for(int i = 0; i < configList.Count; i++)
            {
                Console.WriteLine(configList[i].Item1 + " = " + configList[i].Item2);
            }

            System.IO.File.WriteAllText("Config.settings", string.Empty);
        }
    }
}
