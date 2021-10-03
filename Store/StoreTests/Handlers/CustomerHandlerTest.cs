using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.Commands.CustomerCommands.Inputs;
using StoreDomain.StoreContext.Handlers;
using StoreTests.Fakes;

namespace StoreTests.Handlers
{
    [TestClass]
    public class CustomerHandlerTest
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Felipe";
            command.LastName = "Fon";
            command.Document = "46718115533";
            command.Email = "felipe@gmail.com";
            command.Phone = "11911111111";

            Assert.AreEqual(true, command.IsValid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);

        }
    }
}