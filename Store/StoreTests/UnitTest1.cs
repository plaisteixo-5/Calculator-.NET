using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.ValueObjects;

namespace StoreTests
{
    [TestClass]
    public class DocumentTests
    {
        private Document ValidDocument;
        private Document InvalidDocument;
        public DocumentTests()
        {
            ValidDocument = new Document("1234567891011");
            InvalidDocument = new Document("234");

        }
        [TestMethod]
        public void ShouldCreateCorrecltyDocument()
        {
            Assert.AreEqual("1234567891011", ValidDocument.Number);
        }
    }
}
