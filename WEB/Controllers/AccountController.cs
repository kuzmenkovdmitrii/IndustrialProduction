using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using BLL.Infrastructure;
using BLL.Service;
using Common.Entities;
using WEB.Models;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        //private IUserService userService
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<IUserService>();
        //    }
        //}

        IUserService userService;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    User user = await UserManager.FindAsync(model.UserName, model.Password);
            //    if (user != null)
            //    {
            //        ClaimsIdentity claim =
            //            await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            //        var claims = new List<Claim>
            //        {
            //            new Claim(ClaimsIdentity.DefaultNameClaimType, model.UserName)
            //        };
            //        AuthenticationManager.SignOut();
            //        AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, claim);

            //        return RedirectToAction("Index", "Main");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Неверный логин или пароль");
            //    }
            //}
            //return Redirect("Index");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                ClaimsIdentity claim = await userService.Authenticate(user);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                };

                var result = await userService.Create(user);

                if (result.Successed)
                {
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError(result.Property, result.Message);
                }
            }
            return View(model);
        }
    }
}