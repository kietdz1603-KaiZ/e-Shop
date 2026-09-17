using BlazorApp.demo.Components;
using BlazorApp.demo.Services;
using eShop.DataStore.HardCoded;
using eShop.Usecases.PluginInterfaces.DataStore;
using eShop.Usecases.SearchProductScreen;
using eShop.Usecases.ViewProductScreen;

namespace BlazorApp.demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<ISearchProduct, SearchProduct>();
            builder.Services.AddTransient<IViewProduct, ViewProduct>();

            builder.Services.AddTransient<ICustomerService, CustomerService>();
            //builder.Services.AddSingleton<ICustomerService, CustomerService>();
            //builder.Services.AddScoped<ICustomerService, CustomerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
