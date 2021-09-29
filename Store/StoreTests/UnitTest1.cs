using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreDomain.StoreContext.Entities;
using StoreDomain.StoreContext.ValueObjects;

namespace StoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Felipe", "Fontenele");
            var document = new Document("423243243");
            var email = new Email("teste@teste.com");

            var client = new Customer(
                name,
                document,
                email,
                "983739429",
                "n sei mano"
            );

            var mouse = new Product(
                "Mouse",
                "Equipamento para computador",
                "image.png",
                322.10);
            var teclado = new Product(
                "Teclado",
                "Equipamento para computador",
                "image.png",
                678.10);
            var cadeira = new Product(
                "Cadeira",
                "Cadeira gamer que custa 1000 reais a mais por ser gamer",
                "image.png",
                1222.10);
            var impressora = new Product(
                "Impressora",
                "Equipamento do tinhoso que funciona quando quer",
                "image.png",
                722.10);

            var order = new Order(client);
            order.Add(new OrderItem(mouse, 5));
            order.Add(new OrderItem(teclado, 5));
            order.Add(new OrderItem(impressora, 5));
            order.Add(new OrderItem(cadeira, 5));

            order.Place();



        }
    }
}
