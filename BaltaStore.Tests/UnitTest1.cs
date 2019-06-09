using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
			var name = new Name("Francelio","Alencar");
			var document = new Document("2345654321");
			var email = new Email("francelio@gmail.com");

			var customer = new Customer(name, document, email, "54323432");

			var mouse = new Product("Mouse","Rato","image.png",34.50M,10);
			var teclado = new Product("Teclado", "Teclado", "image.png", 54.50M, 10);
			var cadeira= new Product("Cadeira", "Cadeira", "image.png", 32.50M, 10);
			var impressora = new Product("Impressora", "Impressora", "image.png", 534.50M, 10);

			var order = new Order(customer);
   //         order.AddItem(new OrderItem(mouse,5));
			//order.AddItem(new OrderItem(teclado, 5));
			//order.AddItem(new OrderItem(cadeira, 5));
			//order.AddItem(new OrderItem(impressora, 5));

			//simular o pedido
			order.Place();
			// verificar se o pedido é valido
			var valid = order.Valid;

			//simular pagamento
			order.Pay();

			//simular envio
			order.Ship();

			//simular cancelamento
			order.Cancel();






		}
    }
}
