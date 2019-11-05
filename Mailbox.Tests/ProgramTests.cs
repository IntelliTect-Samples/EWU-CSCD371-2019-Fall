using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOwnerDisplay_NullParameter_ThowsException()
        {
            //Program.GetOwnerDisplay(null);
        }
    }
}
