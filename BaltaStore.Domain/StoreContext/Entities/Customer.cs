using BaltaStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
	{
		private readonly IList<Address> _addresses;

		public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
			Name = Name;
            Document = document;
            Email = email;
            Phone = phone;
			_addresses = new List<Address>();
        }
		public Name Name { get; private set; }
		public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

		public void AddAddress(Address address)
		{
			//Validar o endereço
			//Adicionar o endereço
			_addresses.Add(address);
		}

		//sobrecrevendo o metodo Tostring caso contrario return namespace+custumer
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}