using Core.BocaSuja.Domain.Entities.Base;
using Core.BocaSuja.Domain.Params;

namespace Core.BocaSuja.Infrastructure.Repositories.Interfaces;

public interface IRepository<TEntity, TParams>
    where TEntity : EntidadeBase
    where TParams : IParams
{
    IQueryable<TEntity> Select(TParams @params);
    IQueryable<TEntity> Select();
    Task<TEntity?> Select(Guid id);
    Task Insert(TEntity obj);
    Task InsertMany(IEnumerable<TEntity> objs);
    Task Update(Guid id, TParams @params);
    Task Delete(Guid id);
}
