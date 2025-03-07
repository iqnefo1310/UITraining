using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models.Db;
using UITraining.Models.DTO;

namespace UITraining.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _interface;
        private readonly ISupplier _supplier;
        public ProductController(IProduct interfaces, ISupplier supplier)
        {
            _supplier = supplier;
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
            ViewBag.Supplier = _supplier.Suppliers();
            var products = _interface.GetProductbyId(Id);
            return View(products);
        }
        [HttpPost]
        public IActionResult Edit(ProductDTO product)
        {
            if (product.Id == 0)
            {
                var addProduct = _interface.AddProduct(product);
                if (addProduct)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                var Editproduct = _interface.EditProduct(product);
                if (Editproduct)
                {
                    return RedirectToAction(nameof(Index));
                }
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
