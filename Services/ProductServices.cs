using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.Db;

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
                }).ToList();

            return data;
        }
    }
}
