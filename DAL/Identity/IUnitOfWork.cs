using System.Threading.Tasks;
using DAL.Repository.Interface;

namespace DAL.Identity
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
