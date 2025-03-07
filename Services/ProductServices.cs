using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.Db;
using UITraining.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static UITraining.Models.GeneralStatus;

namespace UITraining.Services
{

    public class ProductServices : IProduct
    {
        private readonly ApplicationContext _context;
        public ProductServices(ApplicationContext context)
        {
            _context = context;
        }
        public List<ProductDTO> GetProduct()
        {
            var data = _context.Products
                .Include(y => y.Supplier)
                .Where(x => x.ProductStatus != GeneralStatusData.deleted)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Stock = x.Stock,
                    ProductStatus = x.ProductStatus,
                    SupplierName = x.Supplier.SupplierName
                }).ToList();

            return data;
        }
        public Product GetProductbyId(int id)
        {
            var product = _context.Products
                .Where(x => x.Id == id && x.ProductStatus != GeneralStatusData.deleted).FirstOrDefault();
            if (product == null)
            {
                return new Product();
            }
            return product;
        }
        public bool EditProduct(ProductDTO product)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (data == null)
            {
                return false;
            }
            data.Name = product.Name;
            data.Description = product.Description;
            data.Price = product.Price;

            data.Stock = product.Stock;
            data.ProductStatus = product.ProductStatus;

            _context.Products.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool AddProduct(ProductDTO product)
        {
            var data = new Product();

            data.Name = product.Name;
            data.Description = product.Description;
            data.Price = product.Price;

            data.Stock = product.Stock;
            data.ProductStatus = product.ProductStatus;
            data.IdSupplier = product.IdSupplier;

            _context.Add(data);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                var dataBarang = _context.Products.FirstOrDefault(x => x.Id == id);
                if (dataBarang != null)
                {
                    dataBarang.ProductStatus = GeneralStatusData.deleted;

                    _context.Products.Update(dataBarang);
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
