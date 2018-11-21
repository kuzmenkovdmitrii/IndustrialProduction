using BLL.Service;
using DAL.Context;
using DAL.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(UserStore.App_Start.Startup))]

namespace UserStore.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}