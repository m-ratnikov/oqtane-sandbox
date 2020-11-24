using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using QB.Customer.Models;

namespace QB.Customer.Services
{
    public class CustomerService : ServiceBase, ICustomerService, IService
    {
        private readonly SiteState _siteState;

        public CustomerService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "Customer");

        public async Task<List<Models.Customer>> GetCustomersAsync(int ModuleId)
        {
            List<Models.Customer> Customers = await GetJsonAsync<List<Models.Customer>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Customers.OrderBy(item => item.FirstName).ToList();
        }

        public async Task<Models.Customer> GetCustomerAsync(int CustomerId, int ModuleId)
        {
            return await GetJsonAsync<Models.Customer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{CustomerId}", ModuleId));
        }

        public async Task<Models.Customer> AddCustomerAsync(Models.Customer Customer)
        {
            return await PostJsonAsync<Models.Customer>(CreateAuthorizationPolicyUrl($"{Apiurl}", Customer.ModuleId), Customer);
        }

        public async Task<Models.Customer> UpdateCustomerAsync(Models.Customer Customer)
        {
            return await PutJsonAsync<Models.Customer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Customer.CustomerId}", Customer.ModuleId), Customer);
        }

        public async Task DeleteCustomerAsync(int CustomerId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{CustomerId}", ModuleId));
        }
    }
}
