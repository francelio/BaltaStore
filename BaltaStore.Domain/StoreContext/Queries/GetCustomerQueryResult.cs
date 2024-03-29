using System;

namespace BaltaStore.Domain.StoreContext.Queries
{
    public class GetCustomerQueryResult
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}