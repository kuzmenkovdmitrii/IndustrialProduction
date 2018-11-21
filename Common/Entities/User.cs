using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Common.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string Password { get; set; }

        //public override string Email { get; set; }

        //public override string UserName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
