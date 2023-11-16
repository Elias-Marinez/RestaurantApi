
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

    }
}
