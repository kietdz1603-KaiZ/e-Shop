using BlazorApp.demo.Models;

namespace BlazorApp.demo.Services
{
    public interface ICustomerService
    {
        Customer? GetCustomerById(int id);
    }
}
