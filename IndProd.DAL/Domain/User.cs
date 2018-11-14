using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndProd.DAL.Domain
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
