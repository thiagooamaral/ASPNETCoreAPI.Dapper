using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Thiago";
            command.LastName = "Amaral";
            command.Document = "87820084006";
            command.Email = "teste@gmail.com";
            command.Phone = "11999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
