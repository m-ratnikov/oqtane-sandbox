using System.Collections.Generic;
using System.Threading.Tasks;
using QB.Customer.Models;

namespace QB.Customer.Services
{
    public interface ICustomerService 
    {
        Task<List<Models.Customer>> GetCustomersAsync(int ModuleId);

        Task<Models.Customer> GetCustomerAsync(int CustomerId, int ModuleId);

        Task<Models.Customer> AddCustomerAsync(Models.Customer Customer);

        Task<Models.Customer> UpdateCustomerAsync(Models.Customer Customer);

        Task DeleteCustomerAsync(int CustomerId, int ModuleId);
    }
}
