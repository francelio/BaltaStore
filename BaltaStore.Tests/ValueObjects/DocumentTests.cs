using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
		/*Red,Green, Refactor. Ou seja:
		Escrevemos um Teste que inicialmente não passa (Red)
		Adicionamos uma nova funcionalidade do sistema
		Fazemos o Teste passar (Green)
		Refatoramos o código da nova funcionalidade (Refactoring)
		Escrevemos o próximo Teste*/
		private Document validDocument;
		private Document invalidDocument;
		public DocumentTests()
		{
			validDocument = new Document("28659170377");
			invalidDocument = new Document("12345678910");
		}
	    [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
			//Escrevemos um Teste que inicialmente não passa (Red)
			//Assert.Fail();
			//Fazemos o Teste passar (Green)
			Assert.AreEqual(false, invalidDocument.Valid);
			Assert.AreEqual(1, invalidDocument.Notifications.Count);
		}
		 [TestMethod]
		 public void ShouldReturnNotNotificationWhenDocumentIsNotValid()
        {
			Assert.AreEqual(true, validDocument.Valid);
			Assert.AreEqual(0, validDocument.Notifications.Count);
		}
    }
}
