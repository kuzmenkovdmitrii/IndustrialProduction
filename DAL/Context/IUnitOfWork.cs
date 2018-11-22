using System.Threading.Tasks;
using DAL.Identity;
using DAL.Repository.Interface;

namespace DAL.Context
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
