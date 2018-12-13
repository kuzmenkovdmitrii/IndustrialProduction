using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            return DB.Orders.Include(x => x.Product)
                .Include(x => x.Periodicity)
                .Include(x => x.Status)
                .Include(x => x.User)
                .ToList();
        }

        public Order Get(int id)
        {
            return DB.Orders.Include(x => x.Product)
                .Include(x => x.Periodicity)
                .Include(x => x.Status)
                .Include(x=>x.User)
                .FirstOrDefault(x=>x.Id == id);
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
