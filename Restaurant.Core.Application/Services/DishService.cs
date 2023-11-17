
using AutoMapper;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class DishService : GenericService<DishResponse, DishRequest, DishUpdRequest, Dish>, IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IIngredientRepository _ingredientRepository;

        private readonly IMapper _mapper;

        public DishService(IDishRepository repository, IMapper mapper, IIngredientRepository ingredientRepository) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }

        public override async Task Add(DishRequest sr)
        {
            Dish entity = _mapper.Map<Dish>(sr);

            foreach (var id in sr.Ingredients)
            {
                var ingredient = await _ingredientRepository.GetByIdAsync(id);

                if (ingredient != null)
                    entity.Ingredients.Add(ingredient);
            }

            await _repository.AddAsync(entity);
        }
        public override async Task<DishResponse> Update(DishUpdRequest sr, int id)
        {
            if(sr.Ingredients != null)
            {
                Dish entity = new();

                foreach (var ingredientId in sr.Ingredients)
                {
                    var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);

                    if (ingredient != null)
                        entity.Ingredients.Add(ingredient);
                }

                var result = await _repository.UpdateAsync(entity, id);

                return _mapper.Map<DishResponse>(result);
            }
            else
            {
                return new DishResponse()
                {
                    HasError = true,
                    Error = "No ingredients were chosen"
                };
            }
        }
    }
}
