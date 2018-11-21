using BLL.Service;
using Ninject.Modules;

namespace WEB.Dep
{
    public class WEBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}