using ApiRest.Domain;
using ApiRest.Infra.Interfaces;

namespace ApiRest.Infra.Implementations
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly MainContext _db;

        public CustomerRepositoryImpl(MainContext db)
        {
            _db = db;
        }

        public async Task Add(Customer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Customer> GetAll()
        {
            return _db.Customer;
        }

        public IQueryable<Customer> GetById(Guid id)
        {
            return from customer in _db.Customer
                        where customer.Id == id
                        select customer;

        }
    }
}
