using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using CRUD_project.Infra.Context;

namespace CRUD_project.Infra.Repository.GenericRepository
{
    public class DesenvolvedoresRepository : GenericRepository<Desenvolvedores>, IDesenvolvedoresRepository
    {
        public DesenvolvedoresRepository(MainContext context) : base(context)
        {

        }
    }
}
