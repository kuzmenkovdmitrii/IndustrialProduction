using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using BLL.Service;
using BLL.Service.Interface;
using Common.Entities;
using Microsoft.AspNet.Identity;
using WEB.Models;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        IUserService UserService { get; }
        IOrderService OrderService { get; }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserService userService, IOrderService orderService)
        {
            UserService = userService;
            OrderService = orderService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Successed()
        {
            return View();
        }

        public ActionResult Profile()
        {
            //User user = new User();
            //user.FirstName = "Dima";
            //user.LastName = "Kuzmenkov";
            //user.Orders = new List<Order>()
            //{
            //    new Order()
            //    {
            //        Id = 1,
            //        Status = new OrderStatus()
            //        {
            //            Id = 1,
            //            Name = "В обработке"
            //        },
            //        Product = new Product()
            //            {
            //                Id = 1,
            //                Name = "Рельсы",
            //                Price = 132
            //        },
            //        Count = 4
            //    },
            //    new Order()
            //    {
            //        Id = 2,
            //        Status = new OrderStatus()
            //        {
            //            Id = 2,
            //            Name = "Поставлен"
            //        },
            //        Product =  new Product()
            //        {
            //                Id = 3,
            //                Name = "Яблоки",
            //                Price = 12
            //        },
            //        Count = 4
            //    }
            //};
            //return View(user);
            var id = this.User.Identity.GetUserId();

            return View(UserService.Get(id));
        }

        public ActionResult GetOrders()
        {
            //User user = new User();
            //user.FirstName = "Dima";
            //user.LastName = "Kuzmenkov";
            //user.Orders = new List<Order>()
            //{
            //    new Order()
            //    {
            //        Id = 1,
            //        Status = new OrderStatus()
            //        {
            //            Id = 1,
            //            Name = "В обработке"
            //        },
            //        Product = new Product()
            //        {
            //            Id = 1,
            //            Name = "Рельсы",
            //            Price = 132
            //        },
            //        Count = 4,
            //        Payment = 14
            //    },
            //    new Order()
            //    {
            //        Id = 2,
            //        Status = new OrderStatus()
            //        {
            //            Id = 2,
            //            Name = "Поставлен"
            //        },
            //        Product =  new Product()
            //        {
            //            Id = 3,
            //            Name = "Яблоки",
            //            Price = 12
            //        },
            //        Count = 2,
            //        Payment = 3
            //    }
            //};

            //return PartialView(OrderService.GetOrdersByUserId(this.User.Identity.GetUserId()));

            var orders = OrderService.GetOrdersByUserId(this.User.Identity.GetUserId()).ToList();
            return PartialView(orders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };

                var result = await UserService.Create(user);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                ClaimsIdentity claim = await UserService.Authenticate(user);
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
    }
}