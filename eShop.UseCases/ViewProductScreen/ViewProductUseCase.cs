using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.ViewProductScreen.interfaces;

namespace eShop.UseCases.ViewProductScreen
{
    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product? Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
