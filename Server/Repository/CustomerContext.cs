using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using QB.Customer.Models;

namespace QB.Customer.Repository
{
    public class CustomerContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Customer> Customer { get; set; }

        public CustomerContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
