using CRUD_project.Application.Interfaces;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_project.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class CrudController<TEntity, TRepository, TService> : ControllerBase
        where TEntity : BaseEntity
        where TRepository : IGenericRepository<TEntity>
        where TService : IBaseService<TEntity, TRepository>
    {
        private readonly TService _service;

        public CrudController(TService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetById(Guid id)
        {
            var result = await _service.ObterPorIdAsync(id);
            if (result.Error)
                return BadRequest(result);
            else
                return Ok(result);
        }
      
        [HttpGet]
        public async Task<ActionResult<TEntity>> Get()
        {
            var result = await _service.ObterTodosAsync();
            if (result.Error)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity tEntity)
        {
            var result = await _service.PostarAsync(tEntity);
            if (result.Error)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<TEntity>> Put(TEntity tEntity)
        {
            var result = await _service.AlterarAsync(tEntity);
            if (result.Error)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var result = await _service.DeletarAsync(id);
            if (result == null)
                return BadRequest(result);
            else
                return Ok(result);
        }

        
    }
}
