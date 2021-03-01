using CRUD_project.Domain;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_project.Application.Interfaces
{
    public interface IBaseService<TEntity, TRepository>
        where TEntity : BaseEntity
        where TRepository : IGenericRepository<TEntity>
    {
        Task<Result<IEnumerable<TEntity>>> ObterTodosAsync();
        Task<Result<TEntity>> ObterPorIdAsync(Guid id);
        Task<Result<TEntity>> AlterarAsync(TEntity entity);
        Task<Result<TEntity>> PostarAsync(TEntity entity);
        Task<Result<TEntity>> DeletarAsync(Guid id);
    }
}
