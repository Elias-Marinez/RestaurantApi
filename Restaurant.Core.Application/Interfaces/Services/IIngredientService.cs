
using Restaurant.Core.Application.Dtos.Ingredient;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<IngredientResponse, IngredientRequest, IngredientUpdRequest, Ingredient>
    {

    }
}
