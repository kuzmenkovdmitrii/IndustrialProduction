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

        public virtual ICollection<Order> Orders { get; set; }
    }
}
