using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using DAL.Context;
using DAL.Repository.Interface;

namespace DAL.Repository
{
    public class ProductRepository : CommonRepository, IProductRepository
    {
        public ProductRepository(ApplicationContext db)
        {
            DB = db;
        }

        public IEnumerable<Product> List()
        {
            return DB.Products;
        }

        public async Task<Product> Get(int id)
        {
            return await DB.Products.FindAsync(id);
        }

        public void Create(Product item)
        {
            DB.Products.Add(item);
            Save();
        }

        public void Update(Product item)
        {
            DB.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var product = DB.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                DB.Products.Remove(product);
                Save();
            }
        }
    }
}
