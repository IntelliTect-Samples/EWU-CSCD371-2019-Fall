using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        public static void Main()
        {
            FileConfig fileConfig = new FileConfig("Config.settings");
            fileConfig.WriteConfig("path1", "value1");
            fileConfig.WriteConfig("path2", "value2");

            List<Tuple<string, string?>> list = fileConfig.ReadConfig();

            for (int ix = 0; ix < 2; ix++)
            {
                Console.WriteLine(list[ix].Item1 + "=" + list[ix].Item2);
            }
        }
    }
}