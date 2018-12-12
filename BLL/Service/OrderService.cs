using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Service.Interface;
using Common.Entities;
using DAL.Context;
using DAL.Repository;
using Microsoft.AspNet.Identity;

namespace BLL.Service
{
    public class OrderService : IOrderService
    {
        IUnitOfWork DB { get; }

        public OrderService(IUnitOfWork db)
        {
            DB = db;
        }

        public OperationDetails Create(Order order)
        {
            if (!CheckExistence(order.Id))
            {
                order.Status = DB.OrderStatusRepository.List().FirstOrDefault(x => x.Name == "В обработке");
                DB.OrderRepository.Create(order);
                return new OperationDetails(true, "Заказ успешно добавлен");
            }

            return new OperationDetails(false, "Заказ уже существует");
        }

        public OperationDetails Delete(int id)
        {
            if (CheckExistence(id))
            {
                DB.OrderRepository.Delete(id);
                return new OperationDetails(true, "Заказ успешно удалён");
            }

            return new OperationDetails(false, "Заказа с таким id не существует");
        }

        public OperationDetails Edit(Order order)
        {
            try
            {
                DB.OrderRepository.Update(order);
                return new OperationDetails(false, "Заказ был успешно обновлён");
            }
            catch
            {
                return new OperationDetails(false, "Заказ не был обновлён");
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return DB.OrderRepository.List();
        }

        public async Task<Order> Get(int id)
        {
            return await DB.OrderRepository.Get(id);
        }

        public IEnumerable<Order> GetOrdersByUserId(string id)
        {
            return DB.UserManager.FindById(id).Orders;
        }

        private bool CheckExistence(int id)
        {
            var check = DB.OrderRepository.Get(id);
            if (check != null)
            {
                return true;
            }

            return false;
        }
    }
}
