using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id != null)
            {
                var order = OrderService.Get(id);


                EditOrderModel model = new EditOrderModel()
                {
                    Id = order.Id,
                    ProductId = order.Product.Id,
                    Count = order.Count,
                    Monday = order.Periodicity.Monday,
                    Tuesday = order.Periodicity.Tuesday,
                    Wednesday = order.Periodicity.Wednesday,
                    Thursday = order.Periodicity.Thursday,
                    Friday = order.Periodicity.Friday,
                    Saturday = order.Periodicity.Saturday,
                    Sunday = order.Periodicity.Sunday,

                    OnceAWeek = order.Periodicity.OnceAWeek,
                    TwiceAWeek = order.Periodicity.TwiceAWeek,
                    ThreeTimesAWeek = order.Periodicity.ThreeTimesAWeek,
                    OnceAMonth = order.Periodicity.OnceAMonth
                };

                return View(model);
            }

            return View();
        }

        public ActionResult All()
        {
            return View(OrderService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(CreateOrderModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = ProductService.Get(model.ProductId);
                Order order = new Order()
                {
                    Count = model.Count,
                    Product = product,
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

                var result = OrderService.Create(order, User.Identity.GetUserId());

                if (result.Successed)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return View("All");
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError(result.Property, result.Message);
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditOrderModel model)
        {
            Product product = ProductService.Get(model.ProductId);

            Order order = new Order()
            {
                Id = model.Id,
                Product = product,
                Count = model.Count,
                Periodicity = new Periodicity()
                {
                    Id = model.ProductId,
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
                },
                Payment = model.Count * product.Price
            };

            var result = OrderService.Edit(order);

            if (result.Successed)
            {
                return RedirectToAction("Profile", "Account");
            }
            else
            {
                ModelState.AddModelError(result.Property, result.Message);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var result = OrderService.Cancel(id);

            return RedirectToAction("Profile", "Account");
        }
    }
}