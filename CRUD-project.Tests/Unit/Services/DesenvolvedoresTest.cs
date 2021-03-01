using CRUD_project.Application.Services;
using CRUD_project.Domain.Entities;
using CRUD_project.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CRUD_project.Tests.Unit.Services
{
    public class DesenvolvedoresTest
    {
        private readonly IDesenvolvedoresRepository _desenvolvedoresRepository;
        private readonly DesenvolvedoresService _desenvolvedoresService;
        private static Guid _devsId = Guid.Parse("71945308-D5E2-473A-A5D3-707F9C17F8A6");
        public DesenvolvedoresTest()
        {
            _desenvolvedoresRepository = Substitute.For<IDesenvolvedoresRepository>();
            _desenvolvedoresService = new DesenvolvedoresService(_desenvolvedoresRepository);
        }

        public static IEnumerable<object[]> InLineDataTesteRetornarTodos => new List<object[]>
        {
            new object[] { new List<Desenvolvedores> { GetDevs()}, false, "Registros encontrados." },
            new object[] { new List<Desenvolvedores> { }, true, "Ainda não existem registros." }
        };

        public static IEnumerable<object[]> InLineDataTesteDeveRetornarPorId => new List<object[]>
        {
            new object[] { _devsId, false, "Registro encontrado.", GetDevs() },
            new object[] { _devsId, true, "Registro não encontrado.", null},
        };

        public static IEnumerable<object[]> InLineDataTesteUpdate => new List<object[]>
        {
                new object[] { GetDevs(), true, "Alteração feita com sucesso."},
                new object[] { GetDevs(), false, "Alteração inválida. " }
        };

        public static IEnumerable<object[]> InLineDataTestePostar => new List<object[]>
        {
            new object[] {GetDevs(), true, "Criado com sucesso.", default(Desenvolvedores) },
            new object[] {GetDevs(), false, "Criação inválida.", GetDevs() }
        };

        public static IEnumerable<object[]> InLineDataTesteDeletar => new List<object[]>
        {
            new object[] {_devsId, GetDevs(), "Registro excluído com sucesso." },
            new object[] {_devsId, null, "Registro não excluído. " },
        };

        public static IEnumerable<object[]> InLineDataTesteRetornarDados => new List<object[]>
        {
            new object[] {"DevTest", 24, new List<Desenvolvedores> { GetDevs() } }
        };

        [Theory]
        [MemberData(nameof(InLineDataTesteRetornarTodos))]
        public void Deve_Retornar_Todos(IEnumerable<Desenvolvedores> list, bool retorno, string mensagem)
        {
            var devFake = Task.FromResult(list);
            _desenvolvedoresRepository.GetAllAsync().Returns(devFake);
            var result = _desenvolvedoresService.ObterTodosAsync().Result;
            result.Error.Should().Be(retorno);
            result.Message.ToString().Should().Be(mensagem);
        }

        [Theory]
        [MemberData(nameof(InLineDataTesteDeveRetornarPorId))]
        public void Deve_Retornar_Por_Id(Guid id, bool retorno, string mensagem, Desenvolvedores desenvolvedores)
        {
            _desenvolvedoresRepository.GetByIdAsync(id).Returns(Task.FromResult(desenvolvedores));
            var result = _desenvolvedoresService.ObterPorIdAsync(id).Result;
            result.Error.Should().Be(retorno);
            result.Message.ToString().Should().Be(mensagem);
        }

        [Theory]
        [MemberData(nameof(InLineDataTestePostar))]
        public void Deve_Postar_Corretamente(Desenvolvedores desenvolvedores, bool retorno, string mensagem, Desenvolvedores dbRetorno)
        {
            _desenvolvedoresRepository.CreateAsync(desenvolvedores).Returns(retorno);
            _desenvolvedoresRepository.GetByIdAsync(Guid.Empty).Returns(dbRetorno);
            var result = _desenvolvedoresService.PostarAsync(desenvolvedores).Result;
            result.Error.Should().Be(!retorno);
            result.Message.ToString().Should().Be(mensagem);
        }

        [Theory]
        [MemberData(nameof(InLineDataTesteUpdate))]
        public void Deve_Alterar_Corretamente(Desenvolvedores desenvolvedores, bool retorno, string mensagem)
        {
            desenvolvedores.Id = Guid.NewGuid();
            _desenvolvedoresRepository.GetByIdAsync(desenvolvedores.Id).Returns(Task.FromResult(desenvolvedores));
            _desenvolvedoresRepository.UpdateAsync(desenvolvedores).Returns(Task.FromResult(retorno));
            var result = _desenvolvedoresService.AlterarAsync(desenvolvedores).Result;
            result.Message.ToString().Should().Be(mensagem);
        }

        [Theory]
        [MemberData(nameof(InLineDataTesteDeletar))]
        public void Deve_Deletar_Corretamente(Guid id, Desenvolvedores retorno, string mensagem)
        {
            _desenvolvedoresRepository.GetByIdAsync(id).Returns(Task.FromResult(retorno));
            var result = _desenvolvedoresService.DeletarAsync(id).Result;
            result.Message.ToString().Should().Be(mensagem);
        }

        [Theory]
        [MemberData(nameof(InLineDataTesteRetornarDados))]
        public void Deve_Retornar_Nome_E_Idade(string name, int age, List<Desenvolvedores> desenvolvedores)
        {
            _desenvolvedoresRepository.GetAllAsync().Returns(Task.FromResult((IEnumerable<Desenvolvedores>)desenvolvedores));
            var result = _desenvolvedoresService.ObterPorDadosAsync(name, age).Result;
            result.Should().BeEquivalentTo(desenvolvedores);
        }

        private static Desenvolvedores GetDevs()
        {
            return new Desenvolvedores
                (
                    "DevTest",
                    "Masculino",
                    24,
                    "Escalar",
                    DateTime.Parse("12/12/2020")
                );
        }
    }
}
