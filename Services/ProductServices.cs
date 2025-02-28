using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.Db;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UITraining.Services
{
    public class ProductServices : IProduct
    {
        private readonly ApplicationContext _context;
        public ProductServices(ApplicationContext context)
        {
            _context = context;
        }
        public List<Product> GetProduct()
        {
            var data = _context.Products
                .Where(x => x.ProductStatus != ProductStatus.deleted)
                .Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Stock = x.Stock,
                    ProductStatus = x.ProductStatus
                }).ToList();

            return data;
        }
        public Product GetProductbyId(int id)
        {
            var product = _context.Products
                .Where(x => x.Id == id && x.ProductStatus != ProductStatus.deleted).FirstOrDefault();
            if (product == null)
            {
                return new Product();
            }
            return product;
        }
        public bool EditProduct(Product product)
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
        public bool Delete(int id)
        {
            try
            {
                var dataBarang = _context.Products.FirstOrDefault(x => x.Id == id);
                if (dataBarang != null)
                {
                    dataBarang.ProductStatus = ProductStatus.deleted;

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
