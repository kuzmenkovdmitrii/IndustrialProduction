using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using DAL.Context;
using DAL.Repository.Interface;

namespace DAL.Repository
{
    public class OrderRepository : CommonRepository, IOrderRepository
    {
        public OrderRepository(ApplicationContext db)
        {
            DB = db;
        }

        public IEnumerable<Order> List()
        {
            return DB.Orders;
        }

        public async Task<Order> Get(int id)
        {
            return await DB.Orders.FindAsync(id);
        }

        public void Create(Order item)
        {
            DB.Orders.Add(item);
            Save();
        }

        public void Update(Order item)
        {
            DB.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var order = DB.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                DB.Orders.Remove(order);
                Save();
            }
        }
    }
}
