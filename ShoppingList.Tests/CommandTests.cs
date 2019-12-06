using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace ShoppingList.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Execute_CallsGivenFunction()
        {
            bool commandExecuted = false;
            void FakeFunction() => commandExecuted = true;
            ICommand sut = new Command(FakeFunction);

            sut.Execute(null);

            Assert.IsTrue(commandExecuted);
        }
    }
}