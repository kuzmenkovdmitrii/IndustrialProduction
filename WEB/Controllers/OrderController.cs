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

        public OrderController(IOrderService orderService, IUserService userService)
        {
            OrderService = orderService;
            UserService = userService;
        }

        public ActionResult Create()
        {
            return View();
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
            var order = Mapper.Map<CreateOrderModel, Order>(model);

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