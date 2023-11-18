
using AutoMapper;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Order;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class OrderService : GenericService<OrderResponse, OrderRequest, OrderUpdRequest, Order>, IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper, IDishRepository dishRepository) :base(repository, mapper)
        { 
            _repository = repository;
            _mapper = mapper;
            _dishRepository = dishRepository;
        }

        public override async Task Add(OrderRequest sr)
        {
            Order entity = _mapper.Map<Order>(sr);

            foreach (var id in sr.Dishes)
            {
                Dish dish = await _dishRepository.GetByIdAsync(id);

                if (dish != null)
                {
                    entity.Dishes.Add(dish);
                    entity.SubTotal += dish.Price;
                }
            }

            await _repository.AddAsync(entity);
        }
        public override async Task<OrderResponse> Update(OrderUpdRequest sr, int id)
        {
            if (sr.Dishes != null)
            {
                Order entity = new();

                foreach (var dishId in sr.Dishes)
                {
                    var dish = await _dishRepository.GetByIdAsync(dishId);

                    if (dish != null)
                    {
                        entity.Dishes.Add(dish);
                        entity.SubTotal += dish.Price;
                    }
                }

                var result = await _repository.UpdateAsync(entity, id);

                return _mapper.Map<OrderResponse>(result);
            }
            else
            {
                return new OrderResponse()
                {
                    HasError = true,
                    Error = "No dishes were chosen"
                };
            }
        }

    }
}
