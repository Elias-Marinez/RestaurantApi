
using AutoMapper;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Ingredient;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class IngredientService : GenericService<IngredientResponse, IngredientRequest, IngredientUpdRequest, Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
