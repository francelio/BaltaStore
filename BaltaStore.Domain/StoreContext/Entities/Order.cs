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

		//Criar um pedido
		public void Place()
		{
			//gerar numero do pedido
			Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
			// validar  
		}
		//pagar um pedido 
		public void Pay()
		{
			//validações 
			Status = EOrderStatus.Paid;

		}
		public void Ship()
		{
			//a cada 5 produtos é uma entrega
			var deliveries = new List<Delivery>();
			deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
			var count = 1;

			//quebra as entregas
			foreach (var item in _items)
			{
				if (count == 5)
				{
					count = 1;
					deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
				}

				count++;
			}

			//envia todas as entregas
			deliveries.ForEach(x => x.Ship());

			//adiciona as entregas ao pedido
			deliveries.ForEach(x => _deliveries.Add(x));


		}

		//cancelar um pedido
		public void Cancel()
		{
			Status = EOrderStatus.Canceled;
			//cancelar todas as entregas
			_deliveries.ToList().ForEach(x=>x.Cancel());
		}


	}
}