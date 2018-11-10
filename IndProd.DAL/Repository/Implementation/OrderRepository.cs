using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IndProd.DAL.Domain;
using IndProd.DAL.Repository.Interface;

namespace IndProd.DAL.Repository.Implementation
{
    class OrderRepository : CommonRepository, IOrderRepository
    {
        public IEnumerable<Order> List()
        {
            return db.Orders;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
            Save();
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                db.Orders.Remove(order);
                Save();
            }
        }
    }
}
