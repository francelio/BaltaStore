using System;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
	{
        public Customer(
            string fistName,
            string lastName,
            string document,
            string email,
            string phone,
            string address)
        {
            FistName = fistName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}