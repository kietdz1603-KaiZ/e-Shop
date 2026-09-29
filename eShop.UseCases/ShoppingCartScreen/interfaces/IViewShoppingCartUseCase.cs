using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen.interfaces
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}
