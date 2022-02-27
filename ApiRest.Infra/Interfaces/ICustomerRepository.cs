using ApiRest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Infra.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
        Task Add(Customer entity);
    }
}
