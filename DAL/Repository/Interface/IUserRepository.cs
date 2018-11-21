using Common.Entities;
using DAL.Context;

namespace DAL.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        ApplicationContext DB { get; }
        void Create(User user);
        void Delete(string id);
    }
}
