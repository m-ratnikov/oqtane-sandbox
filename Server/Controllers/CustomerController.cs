using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using QB.Customer.Models;
using QB.Customer.Repository;

namespace QB.Customer.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public CustomerController(ICustomerRepository CustomerRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _CustomerRepository = CustomerRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Customer> Get(string moduleid)
        {
            return _CustomerRepository.GetCustomers(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Customer Get(int id)
        {
            Models.Customer Customer = _CustomerRepository.GetCustomer(id);
            if (Customer != null && Customer.ModuleId != _entityId)
            {
                Customer = null;
            }
            return Customer;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Customer Post([FromBody] Models.Customer Customer)
        {
            if (ModelState.IsValid && Customer.ModuleId == _entityId)
            {
                Customer = _CustomerRepository.AddCustomer(Customer);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Customer Added {Customer}", Customer);
            }
            return Customer;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Customer Put(int id, [FromBody] Models.Customer Customer)
        {
            if (ModelState.IsValid && Customer.ModuleId == _entityId)
            {
                Customer = _CustomerRepository.UpdateCustomer(Customer);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Customer Updated {Customer}", Customer);
            }
            return Customer;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Customer Customer = _CustomerRepository.GetCustomer(id);
            if (Customer != null && Customer.ModuleId == _entityId)
            {
                _CustomerRepository.DeleteCustomer(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Customer Deleted {CustomerId}", id);
            }
        }
    }
}
