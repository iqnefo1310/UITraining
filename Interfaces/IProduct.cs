using UITraining.Models.Db;
using UITraining.Models.DTO;

namespace UITraining.Interfaces
{
    public interface IProduct
    {
        List<ProductDTO> GetProduct();
        public Product GetProductbyId(int id);

        public bool EditProduct(ProductDTO product);
        public bool Delete(int id);

        public bool AddProduct(ProductDTO product);

    }

}
