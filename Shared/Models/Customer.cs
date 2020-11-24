using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace QB.Customer.Models
{
    [Table("QBCustomer")]
    public class Customer : IAuditable
    {
        public int CustomerId { get; set; }
        public int ModuleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
