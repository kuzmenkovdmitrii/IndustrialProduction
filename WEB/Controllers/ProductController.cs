using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using BLL.Service.Interface;
using Common.Entities;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        IProductService ProductService { get; }

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Product product = ProductService.Get(id);
            EditProductModel model = new EditProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
            return View(model);
        }

        public ActionResult All()
        {
            return View(ProductService.GetAll());
        }

        public ActionResult ProductsInSelect()
        {
            var test = ProductService.GetAll();
            return PartialView(test);
        }

        [HttpPost]
        public ActionResult Create(CreateProductModel model)
        {
            var product = Mapper.Map<CreateProductModel, Product>(model);

            var result = ProductService.Create(product);

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

        [HttpPost]
        public ActionResult Edit(EditProductModel model)
        {
            Product product = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };

            var result = ProductService.Edit(product);

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
            ProductService.Delete(id);

            return RedirectToAction("All");
        }
    }
}