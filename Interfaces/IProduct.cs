using UITraining.Models.Db;

namespace UITraining.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProduct();
        public Product GetProductbyId(int id);

        public bool EditProduct(Product product);
        public bool Delete(int id);

    }

}
