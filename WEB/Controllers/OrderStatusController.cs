using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Service;
using BLL.Service.Interface;
using Common.Entities;
using Microsoft.AspNet.Identity;
using WEB.Models;

namespace WEB.Controllers
{
    public class OrderStatusController : Controller
    {
        IOrderStatusService orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            this.orderStatusService = orderStatusService;
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var orderStatus = Mapper.Map<OrderStatus, EditOrderStatusModel>(await orderStatusService.Get(id));
            return View(orderStatus);
        }

        public async Task<ActionResult> All()
        {
            return View(orderStatusService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(CreateOrderStatusModel model)
        {
            var orderStatus = Mapper.Map<CreateOrderStatusModel, OrderStatus>(model);

            var result = orderStatusService.Create(orderStatus);

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

        public ActionResult Edit(EditOrderStatusModel model)
        {
            var orderStatus = Mapper.Map<EditOrderStatusModel, OrderStatus>(model);

            var result = orderStatusService.Edit(orderStatus);

            if (result.Successed)
            {
                return RedirectToAction("All");
            }
            else
            {
                ModelState.AddModelError(result.Property, result.Message);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var result = orderStatusService.Delete(id);

            return RedirectToAction("All", new { userId = User.Identity.GetUserId() });
        }
    }
}