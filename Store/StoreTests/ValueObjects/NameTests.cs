using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.ValueObjects;
using StoreDomain.StoreContext.Entities;

namespace StoreTests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Fontenele");
            Assert.AreEqual(false, name.Valid);
            Assert.AreEqual(1, name.Notifications.Count);

        }
    }
}