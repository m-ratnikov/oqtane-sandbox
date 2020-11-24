using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using QB.Customer.Models;

namespace QB.Customer.Repository
{
    public class CustomerRepository : ICustomerRepository, IService
    {
        private readonly CustomerContext _db;

        public CustomerRepository(CustomerContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Customer> GetCustomers(int ModuleId)
        {
            return _db.Customer.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Customer GetCustomer(int CustomerId)
        {
            return _db.Customer.Find(CustomerId);
        }

        public Models.Customer AddCustomer(Models.Customer Customer)
        {
            _db.Customer.Add(Customer);
            _db.SaveChanges();
            return Customer;
        }

        public Models.Customer UpdateCustomer(Models.Customer Customer)
        {
            _db.Entry(Customer).State = EntityState.Modified;
            _db.SaveChanges();
            return Customer;
        }

        public void DeleteCustomer(int CustomerId)
        {
            Models.Customer Customer = _db.Customer.Find(CustomerId);
            _db.Customer.Remove(Customer);
            _db.SaveChanges();
        }
    }
}
