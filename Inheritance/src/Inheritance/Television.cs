using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Television:Item
    {
        private string Manufacturor { get; set; }

        private string Size { get; set; }

        public override PrintInfo() => $"<{Manufacturor}> - <{Size}>";
    }
}
