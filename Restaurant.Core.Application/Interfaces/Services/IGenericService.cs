
using System.Linq.Expressions;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IGenericService<Response, SaveRequest, UpdateRequest, Entity>
                                    where Response : class
                                    where SaveRequest : class
                                    where UpdateRequest : class
                                    where Entity : class
    {
        Task Add(SaveRequest sr);
        Task<UpdateRequest> GetByIdToUpdate(int id);
        Task<Response> Update(UpdateRequest sr, int id);
        Task Delete(int id);
        Task<List<Response>> Get();
        Task<Response> GetById(int id);
        Task<List<Response>> GetWithAll(params Expression<Func<Entity, object>>[] includes);
    }
}
