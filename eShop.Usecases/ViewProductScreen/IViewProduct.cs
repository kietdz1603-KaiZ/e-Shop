using eShop.CoreBusiness.Models;

namespace eShop.Usecases.ViewProductScreen
{
    public interface IViewProduct
    {
        Product? GetProduct(int id);
        Product? Execute(int id);
    }
}
