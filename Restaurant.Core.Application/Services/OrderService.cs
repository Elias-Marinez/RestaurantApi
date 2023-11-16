
using AutoMapper;
using Restaurant.Core.Application.Dtos.Order;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class OrderService : GenericService<OrderResponse, OrderRequest, OrderUpdRequest, Order>, IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper) :base(repository, mapper)
        { 
            _repository = repository;
            _mapper = mapper;
        }

    }
}
