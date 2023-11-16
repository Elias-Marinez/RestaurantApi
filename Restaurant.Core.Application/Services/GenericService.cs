
using AutoMapper;
using Restaurant.Core.Application.Dtos;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.Interfaces.Services;

namespace Restaurant.Core.Application.Services
{
    public class GenericService<Response, SaveRequest, UpdateRequest, Entity> : IGenericService<Response, SaveRequest, UpdateRequest, Entity>
        where Response : BaseResponse
        where SaveRequest : class
        where UpdateRequest : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        private IIngredientRepository repository;
        private IMapper mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Add(SaveRequest sr)
        {
            Entity entity = _mapper.Map<Entity>(sr);
            await _repository.AddAsync(entity);
        }
        public virtual async Task<Response> Update(UpdateRequest ur, int id)
        {
            Entity entity = _mapper.Map<Entity>(ur);
            var result = await _repository.UpdateAsync(entity, id);

            Response response = _mapper.Map<Response>(result);

            return response;
        }

        public virtual async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<List<Response>> Get()
        {
            var entities = await _repository.GetAllAsync();
            List<Response> result = _mapper.Map<List<Response>>(entities);

            return result;
        }

        public virtual async Task<List<Response>> GetWithAll()
        {
            var entities = await _repository.GetAllWithIncludeAsync();
            List<Response> result = _mapper.Map<List<Response>>(entities);

            return result;
        }

        public virtual async Task<Response> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            Response result = _mapper.Map<Response>(entity);

            return result;
        }

        public virtual async Task<UpdateRequest> GetByIdToUpdate(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            UpdateRequest result = _mapper.Map<UpdateRequest>(entity);

            return result;
        }
    }

}