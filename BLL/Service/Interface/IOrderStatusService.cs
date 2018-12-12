using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;

namespace BLL.Service.Interface
{
    public interface IOrderStatusService
    {
        OperationDetails Create(OrderStatus orderStatus);
        OperationDetails Delete(int id);
        OperationDetails Edit(OrderStatus orderStatus);
        IEnumerable<OrderStatus> GetAll();
        Task<OrderStatus> Get(int id);
    }
}
