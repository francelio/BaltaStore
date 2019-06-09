using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order 
    {
		private readonly IList<OrderItem> _items;
		private readonly IList<Delivery> _deliveries;
		public Order(Customer custumer)
		{
			Customer = custumer;
			Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
			CreateDate = DateTime.Now;
			Status = EOrderStatus.Created;
			_items = new List<OrderItem>();
			_deliveries = new List<Delivery>();
		}
		public Customer Customer  { get; private set; }
        public string Number { get;private  set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
		public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
		public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
		//IReadOnlyCollection coleção somente leitura

		public void AddItem(OrderItem item)
		{
			//validar item se tem em estoque, se o preco esta correto
			//adiciona item  ao pedido
			_items.Add(item);
		}
		public void AddDelivery(Delivery delivery)
		{
			//validar item se tem em estoque, se o preco esta correto
			//adiciona item  ao pedido
			_deliveries.Add(delivery);
		}
		//To Place An Order
		public void Place()
		{

		}
		
	}
}