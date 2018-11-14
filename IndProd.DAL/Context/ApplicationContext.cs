using System.Data.Entity;
using IndProd.DAL.Domain;

namespace IndProd.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<IdentityContext> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationContext()
            : base("IndProdDB3")
        {

        }
    }
}
