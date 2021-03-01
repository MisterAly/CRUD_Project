using CRUD_project.Application.Interfaces;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_project.Application.Services
{
    public class DesenvolvedoresService : BaseService<Desenvolvedores, IDesenvolvedoresRepository>, IDesenvolvedoresService
    {
        public DesenvolvedoresService(IDesenvolvedoresRepository repository) : base(repository) 
        {
        }

        public async Task<IEnumerable<Desenvolvedores>> ObterPorDadosAsync(string nome, int idade)
        {
            var dados = await _repository.GetAllAsync();
            var filtro = dados.Where(q => (q.Nome == nome && q.Idade == idade )).ToList();
           
            return filtro;
        }
    }
}
