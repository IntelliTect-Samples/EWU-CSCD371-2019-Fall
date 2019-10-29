using Configuration.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void RunApp()
        {
            bool success = Program.RunApp(new MockConfig());

            Assert.IsTrue(success);
        }
    }
}
