using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;

namespace BLL.Service.Interface
{
    public interface IOrderService
    {
        OperationDetails Create(Order order, string userId);
        OperationDetails Cancel(int id);
        OperationDetails Edit(Order order);
        IEnumerable<Order> GetAll();
        Order Get(int id);
        IEnumerable<Order> GetOrdersByUserId(string id);
    }
}
