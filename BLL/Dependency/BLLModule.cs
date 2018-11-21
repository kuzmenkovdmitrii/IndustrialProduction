using DAL.Identity;
using DAL.Repository;
using DAL.Repository.Interface;
using Ninject.Modules;

namespace BLL.Dependency
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}