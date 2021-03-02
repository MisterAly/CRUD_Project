using CRUD_project.Application.Interfaces;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_project.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedoresController : CrudController<Desenvolvedores, IDesenvolvedoresRepository, IDesenvolvedoresService>
    {
        private readonly IDesenvolvedoresService _service;
        public DesenvolvedoresController(IDesenvolvedoresService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("desenvolvedores")]
        public async Task<ActionResult<IEnumerable<Desenvolvedores>>> GetNameAge(string name, int age)
        {
            var dados = await _service.ObterPorDadosAsync(name, age);
            return Ok(dados);
        }

    }
}
