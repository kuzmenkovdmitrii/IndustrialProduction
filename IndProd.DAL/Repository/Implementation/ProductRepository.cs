using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndProd.DAL.Domain;
using IndProd.DAL.Repository.Interface;

namespace IndProd.DAL.Repository.Implementation
{
    class ProductRepository : CommonRepository, IProductRepository
    {
        public IEnumerable<Product> List()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
            Save();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                Save();
            }
        }
    }
}
