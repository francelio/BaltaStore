using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName ="francelio";
            command.LastName = "Alencar";
            command.Document = "46718115533";
            command.Email = "hello@gmail.com";
            command.Phone = "6614551";

            Assert.AreEqual(true,command.Valido());
            
            var handler = new CustomerHandler(new FakeCustomerRepository(),new FakeEmailService());
        }

    }
}