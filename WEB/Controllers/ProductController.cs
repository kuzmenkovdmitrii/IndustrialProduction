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

        public async Task<ActionResult> Edit(int id)
        {
            var product = Mapper.Map<Product, EditProductModel>(await ProductService.Get(id));
            return View(product);
        }

        public async Task<ActionResult> All()
        {
            return View(ProductService.GetAll());
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

        public ActionResult Edit(ProductModel model)
        {
            var product = Mapper.Map<ProductModel, Product>(model);

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