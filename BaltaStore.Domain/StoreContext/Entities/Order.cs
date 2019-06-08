using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order 
    {
		public Order(Customer custumer)
		{
			Customer = custumer;
			Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
			CreateDate = DateTime.Now;
			Status = EOrderStatus.Created;
			Items = new List<OrderItem>();
			Deliveries = new List<Delivery>();
		}
		public Customer Customer  { get; private set; }
        public string Number { get;private  set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
		public IReadOnlyCollection<OrderItem> Items { get; private set; }
		public IReadOnlyCollection<Delivery> Deliveries { get; private set; }
		//IReadOnlyCollection coleção somente leitura

		public void AddItem(OrderItem item)
		{
			//validar item se tem em estoque, se o preco esta correto
			//adiciona item  ao pedido
		}
		//To Place An Order
		public void Place()
		{

		}
		
	}
}