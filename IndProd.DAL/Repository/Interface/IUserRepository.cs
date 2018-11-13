using IndProd.DAL.Context;
using IndProd.DAL.Domain;

namespace IndProd.DAL.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        IdentityContext DB { get; }
        void Create(User user);
    }
}
