using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private readonly Document _validDocument = new Document("87820084006");
        private readonly Document _invalidDocument = new Document("12345678910");

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, _invalidDocument.IsValid);
            // Assert.AreEqual(1, document.Notifications.Count); // Outra abordagem
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, _validDocument.IsValid);
            // Assert.AreEqual(0, document.Notifications.Count); // Outra abordagem
        }
    }
}
