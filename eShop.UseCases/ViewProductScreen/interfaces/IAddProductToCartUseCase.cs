using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen.interfaces
{
    public interface IAddProductToCartUseCase
    {
        Task Execute(int productId);
    }
}
