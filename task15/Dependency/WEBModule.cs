using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Service;
using Ninject.Modules;
using task15.Models;

namespace task15.Dependency
{
    public class WEBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}