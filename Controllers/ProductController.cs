using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models.Db;

namespace UITraining.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _interface;

        public ProductController (IProduct interfaces)
        {
            _interface = interfaces;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _interface.GetProduct();
            return View(products);
        }
        public IActionResult Edit(int Id)
        {
            var products = _interface.GetProductbyId(Id);
            return View(products);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var Editproduct = _interface.EditProduct(product);
            if (Editproduct)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _interface.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
