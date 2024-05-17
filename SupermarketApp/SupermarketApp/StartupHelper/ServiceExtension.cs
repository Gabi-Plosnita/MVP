using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.DataAccessLayer.Repository;

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
            // Configure the services //
            services.AddTransient<IRepository, Repository>(); // delete this

            services.AddTransient<BaseRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddDatabaseServices(this IServiceCollection services, string connectionString)
        {
            // Configure the database services //
            services.AddDbContext<SupermarketDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }
}
