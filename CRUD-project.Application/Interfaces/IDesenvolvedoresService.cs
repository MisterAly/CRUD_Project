using CRUD_project.Domain;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_project.Application.Interfaces
{
    public interface IDesenvolvedoresService : IBaseService<Desenvolvedores, IDesenvolvedoresRepository>
    {
        Task<IEnumerable<Desenvolvedores>> ObterPorDadosAsync(string name, int idade);
    }
}
