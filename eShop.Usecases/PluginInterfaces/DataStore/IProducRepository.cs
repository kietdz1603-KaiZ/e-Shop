using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Usecases.PluginInterfaces.DataStore
{
    public interface IProducRepository
    {
        IEnumerable<Product> getproducts(string filter);
        Product getproducts(int id);
    }
}
