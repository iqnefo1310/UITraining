using Microsoft.AspNetCore.Mvc.Rendering;
using UITraining.Interfaces;
using UITraining.Models;

namespace UITraining.Services
{
    public class SupplierServices : ISupplier
    {
        public readonly ApplicationContext _context;

        public SupplierServices (ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Suppliers()
        {
            var datas = _context.Suppliers
                .Select(x => new SelectListItem
                {
                    Text = x.SupplierName,
                    Value = x.Id.ToString(),
                }).ToList();
            return datas;
        }
    }
}
