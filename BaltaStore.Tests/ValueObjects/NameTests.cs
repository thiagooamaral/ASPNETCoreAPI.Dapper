using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private readonly Name _validName = new Name("Thiago", "Amaral");
        private readonly Name _invalidName = new Name("Thiago", "");

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            Assert.AreEqual(false, _invalidName.IsValid);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenNameIsValid()
        {
            Assert.AreEqual(true, _validName.IsValid);
        }
    }
}
