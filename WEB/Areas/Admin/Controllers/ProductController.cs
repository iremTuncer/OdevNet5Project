using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Service;
using Project.Entity.Entity;
using System.Linq;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Product";
            var products = productService.GetAllProducts().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            TempData["Title"] = "Create Product";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productService.CreateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = productService.Get(id);
            productService.RemoveProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var product = productService.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
