using eShop.CoreBusiness.Models;
using eShop.Usecases.PluginInterfaces.DataStore;

namespace eShop.Usecases.ViewProductScreen
{
    public class ViewProduct : IViewProduct
    {
        private readonly IProductRepository productRepository;

        public ViewProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product? GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public Product? Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
