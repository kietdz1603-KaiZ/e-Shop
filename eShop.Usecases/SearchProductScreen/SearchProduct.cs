using eShop.CoreBusiness.Models;
using eShop.Usecases.PluginInterfaces.DataStore;
using System.Collections.Generic;

namespace eShop.Usecases.SearchProductScreen
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string? filter = null)
        {
            return productRepository.GetProducts(filter);
        }
    }
}
