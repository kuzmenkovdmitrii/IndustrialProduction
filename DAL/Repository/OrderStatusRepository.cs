using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Entities;
using DAL.Context;
using DAL.Repository.Interface;

namespace DAL.Repository
{
    public class OrderStatusRepository : CommonRepository, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationContext db)
        {
            DB = db;
        }

        public IEnumerable<OrderStatus> List()
        {
            return DB.OrderStatuses;
        }

        public  OrderStatus Get(int id)
        {
            return DB.OrderStatuses.Find(id);
        }

        public void Create(OrderStatus item)
        {
            DB.OrderStatuses.Add(item);
            Save();
        }

        public void Update(OrderStatus item)
        {
            DB.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var order = DB.OrderStatuses.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                DB.OrderStatuses.Remove(order);
                Save();
            }
        }
    }
}
