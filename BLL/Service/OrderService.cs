using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Infrastructure;
using BLL.Service.Interface;
using Common.Entities;
using DAL.Context;
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

        public OperationDetails Create(Order order, string userId)
        {
            var user = DB.UserManager.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                order.Status = DB.OrderStatusRepository.List().FirstOrDefault(x => x.Name == "В обработке");
                order.User = user;
                
                user.Orders.Add(order);
                DB.OrderRepository.Create(order);
                DB.UserManager.Update(user);
                return new OperationDetails(true, "Заказ успешно добавлен");
            }
            else
            {
                return new OperationDetails(false, "Пользователь не найден");
            }

        }

        public OperationDetails Cancel(int id)
        {
            var order = DB.OrderRepository.Get(id);

            if (order != null)
            {
                order.Status = DB.OrderStatusRepository.List().FirstOrDefault(x => x.Name == "Отменён");
                DB.OrderRepository.Update(order);
                return new OperationDetails(true, "Заказ успешно отменён");
            }

            return new OperationDetails(false, "Заказа с таким id не существует");
        }

        public OperationDetails Edit(Order item)
        {
            try
            {
                Product product = DB.ProductRepository.Get(item.Product.Id);
                Order order = Get(item.Id);
                order.Count = item.Count;
                order.Payment = product.Price * order.Count;
                order.Periodicity.Monday = item.Periodicity.Monday;
                order.Periodicity.Tuesday = item.Periodicity.Tuesday;
                order.Periodicity.Wednesday = item.Periodicity.Wednesday;
                order.Periodicity.Thursday = item.Periodicity.Thursday;
                order.Periodicity.Friday = item.Periodicity.Friday;
                order.Periodicity.Saturday = item.Periodicity.Saturday;
                order.Periodicity.Sunday = item.Periodicity.Sunday;
                order.Product = product;
                DB.OrderRepository.Update(order);
                return new OperationDetails(true, "Заказ был успешно обновлён");
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Заказ не был обновлён");
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return DB.OrderRepository.List();
        }

        public Order Get(int id)
        {
            return DB.OrderRepository.Get(id);
        }

        public IEnumerable<Order> GetOrdersByUserId(string id)
        {
            return DB.OrderRepository.List().Where(x=>x.User.Id == id);
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
