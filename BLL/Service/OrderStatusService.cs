using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Service.Interface;
using Common.Entities;
using DAL.Context;

namespace BLL.Service
{
    public class OrderStatusService : IOrderStatusService
    {
        IUnitOfWork DB { get; }

        public OrderStatusService(IUnitOfWork db)
        {
            DB = db;
        }

        public OperationDetails Create(OrderStatus orderStatus)
        {
            if (!CheckExistence(orderStatus.Id))
            {
                DB.OrderStatusRepository.Create(orderStatus);
                return new OperationDetails(true, "Статус успешно создан");
            }

            return new OperationDetails(false, "Статус уже существует");
        }

        public OperationDetails Delete(int id)
        {
            if (CheckExistence(id))
            {
                DB.OrderStatusRepository.Delete(id);
                return new OperationDetails(true, "Статус успешно удалён");
            }

            return new OperationDetails(false, "Статуса с таким id не существует");
        }

        public OperationDetails Edit(OrderStatus orderStatus)
        {
            try
            {
                DB.OrderStatusRepository.Update(orderStatus);
                return new OperationDetails(false, "Статус успешно обновлён");
            }
            catch
            {
                return new OperationDetails(false, "Статус не был обновлён");
            }
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return DB.OrderStatusRepository.List();
        }

        public async Task<OrderStatus> Get(int id)
        {
            return await DB.OrderStatusRepository.Get(id);
        }

        private bool CheckExistence(int id)
        {
            var check = DB.OrderStatusRepository.Get(id);
            if (check != null)
            {
                return true;
            }

            return false;
        }
    }
}
