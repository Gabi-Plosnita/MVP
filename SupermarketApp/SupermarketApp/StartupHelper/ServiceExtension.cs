using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.ViewModel;

namespace SupermarketApp.StartupHelper
{
    public static class ServicesExtension
    {
        public static void AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
            services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Confiure Repoitories //
            services.AddTransient<BaseRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IReceiptRepository, ReceiptRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Configure Services //
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IReceiptService, ReceiptService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IUserService, UserService>();

            // Configure ViewModel //
            services.AddTransient<MainViewModel>();
            services.AddTransient<AdminViewModel>();
        }

        public static void AddDatabaseServices(this IServiceCollection services, string connectionString)
        {
            // Configure the database services //
            services.AddDbContext<SupermarketDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }
}
