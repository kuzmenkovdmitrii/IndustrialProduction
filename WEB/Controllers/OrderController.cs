using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using BLL.Service;
using BLL.Service.Interface;
using Common.Entities;
using Microsoft.AspNet.Identity;
using WEB.Models;

namespace WEB.Controllers
{
    public class OrderController : Controller
    {
        IOrderService OrderService { get; }
        IUserService UserService { get; }
        IProductService ProductService { get; }

        public OrderController(IOrderService orderService, IUserService userService, IProductService productService)
        {
            OrderService = orderService;
            UserService = userService;
            ProductService = productService;
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get(int id)
        {
            return View(OrderService.Get(id).Result);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var order = Mapper.Map<Order, EditOrderModel>(await OrderService.Get(id));
            return View(order);
        }

        public async Task<ActionResult> All(string userId)
        {
            var user = await UserService.Get(userId);
            var list = Mapper.Map<ICollection<Order>, IEnumerable<OrderModel>>(user.Orders);
            return View(list);
        }

        [HttpPost]
        public ActionResult Create(CreateOrderModel model)
        {
            Order order = new Order()
            {
                Count = model.Count,
                Product = ProductService.Get(model.ProductId).Result,
                Periodicity = new Periodicity()
                {
                    Monday = model.Monday,
                    Tuesday = model.Tuesday,
                    Wednesday = model.Wednesday,
                    Thursday = model.Thursday,
                    Friday = model.Friday,
                    Saturday = model.Saturday,
                    Sunday = model.Sunday,

                    OnceAWeek = model.OnceAWeek,
                    TwiceAWeek = model.TwiceAWeek,
                    ThreeTimesAWeek = model.ThreeTimesAWeek,
                    OnceAMonth = model.OnceAMonth
                }
            };

            var result = OrderService.Create(order);

            if (result.Successed)
            {
                return View("All");
            }
            else
            {
                ModelState.AddModelError(result.Property, result.Message);
            }

            return View();
        }

        public ActionResult Edit(OrderModel model)
        {
            var order = Mapper.Map<OrderModel, Order>(model);

            var result = OrderService.Edit(order);

            if (result.Successed)
            {
                return RedirectToAction("All", new {User = order.User});
            }
            else
            {
                ModelState.AddModelError(result.Property, result.Message);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var result = OrderService.Delete(id);

            return RedirectToAction("All", new {userId = User.Identity.GetUserId()});
        }
    }
}