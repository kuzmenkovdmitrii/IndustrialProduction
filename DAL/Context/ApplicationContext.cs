using System.Data.Entity;
using Common.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public ApplicationContext() : base("IndProdDB22")
        {

        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
