using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SampleApp;

namespace SampleApp.Tests
{
    [TestClass]
    public class SampleAppTests
    {
        [TestMethod]
        public void SampleApp_PrintList_MockConfig()
        {
            //Arrange
            MockConfig mc = new MockConfig();
            Assert.IsTrue(mc.SetConfigValue("item1", "data1"));
            Assert.IsTrue(mc.SetConfigValue("item2", "data2"));

            //Act
            Program.PrintList(mc.tempSettings);


            //Assert



        }
    }
}
