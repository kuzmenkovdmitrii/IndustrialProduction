using System.Web.Mvc;
using System.Web.Routing;
using BLL.Dependency;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using WEB.Dep;

namespace WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule bllModule = new BLLModule();
            NinjectModule webModule = new WEBModule();
            var kernel = new StandardKernel(bllModule, webModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
