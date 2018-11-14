using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IndProd.DAL.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndProd.DAL.Identity
{
    public class ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
