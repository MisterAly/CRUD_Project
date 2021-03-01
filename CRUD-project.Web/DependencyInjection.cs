using CRUD_project.Application.Interfaces;
using CRUD_project.Application.Services;
using CRUD_project.Domain.Interfaces;
using CRUD_project.Infra.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_project.Web
{
    public static class DependencyInjection
    {
        public static void InjetarDependencias(this IServiceCollection service)
        {
            service.AddScoped<IDesenvolvedoresRepository, DesenvolvedoresRepository>();

            service.AddScoped<IDesenvolvedoresService, DesenvolvedoresService>();
        }
    }
}
