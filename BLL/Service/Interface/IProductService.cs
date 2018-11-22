using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;

namespace BLL.Service.Interface
{
    public interface IProductService
    {
        OperationDetails Create(Product product);
        OperationDetails Delete(int id);
        OperationDetails Edit(Product product);
        IEnumerable<Product> GetAll();
        Task<Product> Get(int id);
    }
}
