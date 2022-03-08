using ApiRest.Domain;


namespace ApiRest.Infra.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
        Task Add(Customer entity);
        IQueryable<Customer> GetById(Guid id);
    }
}
