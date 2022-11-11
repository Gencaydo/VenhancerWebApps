using System.Linq.Expressions;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Core.Services
{
    public interface IGenericService<TEntity,TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>>AddAsync(TDto entity);
        Task<Response<NoDataDto>> UpdateAsync(TDto entity,int id);
        Task<Response<NoDataDto>> Remove(int id);
    }
}
