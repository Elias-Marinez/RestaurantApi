
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
        private readonly IMapper _mapper;

        public DishService(IDishRepository repository, IMapper mapper) :base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
