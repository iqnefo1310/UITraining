using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;
using UITraining.Models.DTO;

namespace UITraining.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplier _supplier;
        public SupplierController(ISupplier supplier)
        {
            _supplier = supplier;
        }
        public IActionResult Index()
        {
            var supplier = _supplier.GetSupplier();
            return View(supplier);
        }

        public IActionResult Edit(int id) 
        {
            var ter = _supplier.GetSupplierById(id);

            return View(ter);
        }
        [HttpPost]
        public IActionResult Edit(SupplierDTO supplier)
        {
            if (supplier.Id == 0)
            {
                var addProduct = _supplier.AddSupplier(supplier);
                if (addProduct)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                var Edit = _supplier.EditSupplier(supplier);
                if (Edit)
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
            _supplier.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
