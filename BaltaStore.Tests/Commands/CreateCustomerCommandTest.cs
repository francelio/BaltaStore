using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Francelio";
            command.LastName = "Alencar";
            command.Document = "28659170377";
            command.Email = "francei@gmail.com";
            command.Phone = "9198451841";

            Assert.AreEqual(true, command.Valido());
        }
    }
}