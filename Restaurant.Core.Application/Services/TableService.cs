
using AutoMapper;
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Services
{
    public class TableService : GenericService<TableResponse, TableRequest, TableUpdRequest, Table>, ITableService
    {
        private readonly ITableRepository _repository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository repository, IMapper mapper) :base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task StatusUpdateAsync(TableStatusRequest tsr, int id)
        {
            Table entity = _mapper.Map<Table>(tsr);
            await _repository.StatusUpdateAsync(entity, id);
        }

        public async Task<TableOrderResponse> GetByIdWithOrder(int id)
        {
            var result = await _repository.GetByIdWithOrder(id);

            TableOrderResponse response = _mapper.Map<TableOrderResponse>(result);
            return response;
        }


    }
}
