using BaltaStore.Tests.Fakes;
using BaltaStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Thiago";
            command.LastName = "Amaral";
            command.Document = "87820084006";
            command.Email = "teste@gmail.com";
            command.Phone = "11999999999";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
