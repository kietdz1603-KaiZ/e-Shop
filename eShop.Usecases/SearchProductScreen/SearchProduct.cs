using eShop.Usecases.PluginInterfaces.DataStore;
using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Usecases.SearchProductScreen
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        

        public IEnumerable<Product> Execute(string filter)
        {
            return productRepository.GetProducts(filter);

        }

        public Product Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
