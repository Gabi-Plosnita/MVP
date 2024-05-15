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
            services.AddTransient<IRepository, Repository>();
        }

        public static void AddDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SupermarketDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }
}
