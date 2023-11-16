
namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IGenericService<Response, SaveRequest, UpdateRequest, Entity>
                                    where Response : class
                                    where SaveRequest : class
                                    where UpdateRequest : class
                                    where Entity : class
    {
        Task Add(SaveRequest vm);
        Task<UpdateRequest> GetByIdToUpdate(int id);
        Task<Response> Update(UpdateRequest vm, int id);
        Task Delete(int id);
        Task<List<Response>> Get();
        Task<Response> GetById(int id);
        Task<List<Response>> GetWithAll();
    }
}
