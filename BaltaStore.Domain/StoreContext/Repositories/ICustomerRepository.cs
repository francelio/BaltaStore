using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Domain.StoreContext.Repositories{
    public interface ICustomerRepository
    {
        bool CheckDocument(string documento);
        bool CheckEmail(string email);
        void Save(Customer customer);

    }
}