using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.Commands.CustomerCommands.Inputs;

namespace StoreTests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Felipe";
            command.LastName = "Fon";
            command.Document = "46718115533";
            command.Email = "felipe@gmail.com";
            command.Phone = "11911111111";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}