using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string cstrShoppingCart = "eShop.ShoppingCart";
        private readonly IJSRuntime jsRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            this.jsRuntime = jsRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.Id, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public async Task EmptyAsync()
        {
            await SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            return null;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrder();
            if (quantity <= 0)
                return await DeleteProductAsync(productId);

            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
            if (lineItem != null)
            {
                lineItem.Quantity = quantity;
            }
            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;
            var strOrder = await jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrEmpty(strOrder))
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
