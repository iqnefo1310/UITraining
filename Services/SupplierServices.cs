using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using static UITraining.Models.GeneralStatus;
using UITraining.Models.DTO;
using UITraining.Models.Db;

namespace UITraining.Services
{
    public class SupplierServices : ISupplier
    {
        public readonly ApplicationContext _context;

        public SupplierServices(ApplicationContext context)
        {
            _context = context;
        }
        //PELATIHAN
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
        public List<SupplierDTO> GetSupplier()
        {
            var data = _context.Suppliers
                //.Include(y => y.Supplier)
                .Where(x => x.SupplierStatus != GeneralStatusData.suspended)
                .Select(x => new SupplierDTO
                {
                    Id = x.Id,
                    SupplierName = x.SupplierName,
                    SupplierAddress = x.SupplierAddress,
                    SupplierStatus = x.SupplierStatus,
                }).ToList();

            return data;
        }
        public Supplier GetSupplierById(int id)
        {
            var supplier = _context.Suppliers.Where(x => x.Id == id && x.SupplierStatus != GeneralStatusData.suspended).FirstOrDefault();
            if (supplier == null)
            {
                return new Supplier();
            }
            return supplier;
        }
        public bool EditSupplier(SupplierDTO supplier)
        {
            var data = _context.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
            if (data == null)
            {
                return false;
            }
            data.SupplierName = supplier.SupplierName;
            data.SupplierAddress = supplier.SupplierAddress;

            data.SupplierStatus = supplier.SupplierStatus;

            _context.Suppliers.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool AddSupplier(SupplierDTO supplier)
        {
            var data = new Supplier();

            data.SupplierName = supplier.SupplierName;
            data.SupplierAddress = supplier.SupplierAddress;
            data.SupplierStatus = supplier.SupplierStatus;

            _context.Add(data);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var dataBarang = _context.Suppliers.FirstOrDefault(x => x.Id == id);
                if (dataBarang != null)
                {
                    dataBarang.SupplierStatus = GeneralStatusData.suspended;

                    _context.Suppliers.Update(dataBarang);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}