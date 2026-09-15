using eShop.CoreBusiness.Models;

namespace eShop.Usecases.SearchProductScreen
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);
        Product GetProduct(int id);
        Product GetProducts(int id);
    }
}