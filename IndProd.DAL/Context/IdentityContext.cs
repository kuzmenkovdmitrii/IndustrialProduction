using System.Collections.Generic;
using System.Data.Entity;
using IndProd.DAL.Domain;
using IndProd.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndProd.DAL.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }

        public IdentityContext() : base("IndProdDB2")
        {
        }
    }
}
