using IndProd.BLL.Service.Interface;
using IndProd.DAL.Identity;

namespace IndProd.BLL.Service
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService()
        {
            return new UserService(new IdentityUnitOfWork());
        }
    }
}
