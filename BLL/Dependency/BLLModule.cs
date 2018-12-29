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
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOrderStatusRepository>().To<OrderStatusRepository>();
            //Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}