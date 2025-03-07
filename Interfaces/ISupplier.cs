using Microsoft.AspNetCore.Mvc.Rendering;
using UITraining.Models;

namespace UITraining.Interfaces
{
    public interface ISupplier
    {
        public List<SelectListItem> Suppliers();

    }
}
