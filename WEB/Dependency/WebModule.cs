using BLL.Service;
using BLL.Service.Interface;
using Ninject.Modules;

namespace WEB.Dep
{
    public class WEBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IProductService>().To<ProductService>();
        }
    }
}