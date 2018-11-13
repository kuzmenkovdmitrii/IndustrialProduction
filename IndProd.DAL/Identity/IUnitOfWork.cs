using System.Threading.Tasks;
using IndProd.DAL.Repository.Interface;

namespace IndProd.DAL.Identity
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
