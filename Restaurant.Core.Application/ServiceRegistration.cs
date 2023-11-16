
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.Services;
using System.Reflection;

namespace Restaurant.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Services
            services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));

            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<IOrderService, OrderService>();
            #endregion
        }
    }
}
