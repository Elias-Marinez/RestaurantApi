
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Infrastructure.Persistence.Context;
using Restaurant.Infrastructure.Persistence.Repositories;

namespace Restaurant.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            services.AddDbContext<ApplicationContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion
        }
    }
}
