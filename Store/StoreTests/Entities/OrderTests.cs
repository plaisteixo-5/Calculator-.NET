using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.Enums;
using StoreDomain.StoreContext.ValueObjects;

namespace StoreTests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Order _order;
        private Product _mouse;
        private Product _chair;
        private Product _keyboard;
        private Product _monitor;
        private Product _piscina;
        public OrderTests()
        {
            var name = new Name("Felipe", "Fon");
            var document = new Document("46718115533");
            var email = new Email("teste@gmail.com");
            var customer = new Customer(name, document, email, "983748");
            _order = new Order(customer);
            _mouse = new Product("Mouse Gamer ", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer ", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer ", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer ", "Monitor Gamer", "monitor.jpg", 100M, 10);
            _piscina = new Product("Piscina Gamer ", "Piscina Gamer", "piscina.jpg", 100M, 10);
        }

        // Criar novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_piscina, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenPurchasedTenProducts()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreNotEqual(EDeliveryStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);

            }
        }

        public void CreateCustomer()
        {
            // 1 - Verificar se email e CPF já existem
            // 2 -Criar os VO's
            // 3 - Validar entidades e VO's
            // 4 - Inserir cliente no banco
        }
    }
}
