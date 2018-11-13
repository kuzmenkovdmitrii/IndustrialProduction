using IndProd.BLL.Service;
using IndProd.BLL.Service.Interface;
using Ninject.Modules;

namespace IndProd.BLL.Dependency
{
    class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}
