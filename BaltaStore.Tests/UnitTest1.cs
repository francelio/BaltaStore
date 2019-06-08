using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
             var c = new Customer(
                "Francelio",
                "Alencar",
                "12345432",
                "hello@francelio.com",
                "123223321",
                "Rua teste 30"
            );
            
            var order = new Order(c);
            order.AddItem();


           

        }
    }
}
