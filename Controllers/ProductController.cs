using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;

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
            return View();
        }
    }
}
