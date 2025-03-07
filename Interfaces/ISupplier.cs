using Microsoft.AspNetCore.Mvc.Rendering;
using UITraining.Models.Db;
using UITraining.Models.DTO;

namespace UITraining.Interfaces
{
    public interface ISupplier
    {
        public List<SelectListItem> Suppliers();
        public List<SupplierDTO> GetSupplier();
        public Supplier GetSupplierById(int id);
        public bool EditSupplier(SupplierDTO supplier);
        public bool AddSupplier(SupplierDTO supplier);
        public bool Delete(int id);

        /*public SupplierDTO GetSupplierById(int id);*/

    }
}
