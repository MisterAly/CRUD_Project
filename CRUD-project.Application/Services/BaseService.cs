using CRUD_project.Domain;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_project.Application.Services
{
    public class BaseService<TEntity, TRepository> 
        where TEntity : BaseEntity
        where TRepository : IGenericRepository<TEntity>
    {
        protected readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<TEntity>>> ObterTodosAsync()
        {
            var tEntity = await _repository.GetAllAsync();
            if (tEntity.Any())
            {
                return new Result<IEnumerable<TEntity>>(tEntity, false, "Registros encontrados.");
            }
            return new Result<IEnumerable<TEntity>>(true, "Ainda não existem registros.");
        }

        public async Task<Result<TEntity>> ObterPorIdAsync(Guid id)
        {
            var tEntity = await _repository.GetByIdAsync(id);
            if(tEntity != null)
            {
                return new Result<TEntity>(tEntity, false, "Registro encontrado.");
            }
            return new Result<TEntity>(true, "Registro não encontrado.");
        }

        public async Task<Result<TEntity>> AlterarAsync(TEntity tEntity)
        {
            if (tEntity != null )
            {
                var filter = await _repository.GetByIdAsync(tEntity.Id);
                if(filter != null)
                {
                    var valid = await _repository.UpdateAsync(tEntity);
                    return new Result<TEntity>(valid, "Alteração feita com sucesso.");
                }
            }
            return new Result<TEntity>(false, "Alteração inválida. ");
        }

        public async Task<Result<TEntity>> PostarAsync(TEntity tEntity)
        {
            if(tEntity != null)
            {
                var filter = await _repository.GetByIdAsync(tEntity.Id);
                if(filter == null)
                {
                    var valid = await _repository.CreateAsync(tEntity);
                    return new Result<TEntity>(valid, "Criado com sucesso." );
                }
            }
                return new Result<TEntity>(false, "Criação inválida.");
        }

        public async Task<Result<TEntity>> DeletarAsync(Guid id)
        {
            if(await _repository.GetByIdAsync(id) == null)
            {
                return new Result<TEntity>(true, "Registro não excluído. ");
            }
            else
            {
                return new Result<TEntity>(await _repository.DeleteAsync(id), "Registro excluído com sucesso.");
            }
        }
    }

}
