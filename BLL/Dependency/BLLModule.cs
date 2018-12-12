using DAL.Context;
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
            Bind<IOrderRepository>().To<OrderRepository>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<IOrderStatusRepository>().To<OrderStatusRepository>().InSingletonScope();
            //Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}