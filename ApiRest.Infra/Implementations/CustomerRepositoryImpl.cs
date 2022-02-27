using ApiRest.Domain;
using ApiRest.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
