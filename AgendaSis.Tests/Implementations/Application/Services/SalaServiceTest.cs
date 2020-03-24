using AgendaSis.Application.Models.Salas;
using AgendaSis.Application.Services.Salas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Tests.Builders;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgendaSis.Tests.Implementations.Application.Services
{
    public class SalaServiceTest
    {
        private readonly ISalaService _salaSvc;
        private readonly ISalaRepository _salaRepo;

        public SalaServiceTest()
        {
            _salaRepo = Substitute.For<ISalaRepository>();
            _salaSvc = new SalaService(_salaRepo);
        }

        [Theory]
        [InlineData("Cobol", 6, 1)]
        [InlineData("Python", 7, 1)]
        [InlineData("DC", 10, 3)]
        [InlineData("Marvel", 3, 3)]
        public async Task deve_criar_sala_com_os_parametros_corretos(string nome, int capacidade, int andar)
        {
            var salaDto = new SalaRequestDto
            {
                Nome = nome,
                Capacidade = capacidade,
                Andar = andar
            };

            var salaResponse = await _salaSvc.CreateAsync(salaDto);

            //await _salaRepo
            //    .Received(1)
            //    .CreateAsync(Arg.Is<Sala>(d =>
            //        d.Nome == salaDto.Nome &&
            //        d.Andar == salaDto.Andar &&
            //        d.Capacidade == salaDto.Capacidade
            //    ));

            Assert.True(salaResponse.Nome == salaDto.Nome);
            Assert.True(salaResponse.Andar == salaDto.Andar);
            Assert.True(salaResponse.Capacidade == salaDto.Capacidade);
        }

        [Theory]
        [InlineData("", 1, 1)]
        [InlineData(null, 3, 3)]
        public async Task deve_dar_erro_ao_tentar_criar_sala_com_nome_vazio(string nome, int capacidade, int andar)
        {
            var salaDto = new SalaRequestDto
            {
                Nome = nome,
                Capacidade = capacidade,
                Andar = andar
            };

            //var salaResponse = await _salaSvc.CreateAsync(salaDto);
            Func<Task> func = async () => await _salaSvc.CreateAsync(salaDto);
            func.Should().Throw<Exception>().WithMessage("Ocorreu os seguintes erros:\n- O nome da sala não pode ser vazia\n");
        }

        [Theory]
        [InlineData("Marvel", -1, 1)]
        [InlineData("DC", 0, 3)]
        public async Task deve_dar_erro_ao_tentar_criar_sala_com_capacidade_zero(string nome, int capacidade, int andar)
        {
            var salaDto = new SalaRequestDto
            {
                Nome = nome,
                Capacidade = capacidade,
                Andar = andar
            };

            //var salaResponse = await _salaSvc.CreateAsync(salaDto);
            Func<Task> func = async () => await _salaSvc.CreateAsync(salaDto);
            func.Should().Throw<Exception>().WithMessage("Ocorreu os seguintes erros:\n- A sala deve ter pelo menos um lugar\n");
        }

        [Theory]
        [InlineData("Cobol", 6, 1)]
        [InlineData("Python", 7, 1)]
        [InlineData("DC", 10, 3)]
        [InlineData("Marvel", 3, 3)]
        public async Task deve_atualizar_a_sala(string nome, int capacidade, int andar)
        {
            var id = 2;
            var salaDto = new SalaRequestDto
            {
                Nome = nome,
                Capacidade = capacidade,
                Andar = andar
            };

            var sala = new SalaBuilder()
                            .ComId(id)
                            .ComNome("Nome da Sala")
                            .ComAndar(10)
                            .ComCapacidade(50)
                            .Build();

            _salaRepo.GetByIdAsync(id).Returns(sala);

            await _salaSvc.UpdateAsync(id, salaDto);

            await _salaRepo
                .Received(1)
                .UpdateAsync(Arg.Is<Sala>(d => 
                    d.Nome == salaDto.Nome &&
                    d.Andar == salaDto.Andar &&
                    d.Capacidade == salaDto.Capacidade
                ));
        }

        [Fact]
        public async Task deve_retornar_uma_lista_de_salas()
        {
            var listaFake = new List<Sala>
            {
                new Sala("Marvel", 2, 6),
                new Sala("DC", 2, 6),
                new Sala("Python", 2, 6),
                new Sala("Cobol", 2, 6),
                new Sala("Shenlong", 2, 6),
                new Sala("Star Trek", 2, 6),
                new Sala("Star Wars", 2, 6),
            };

            _salaRepo.GetAllAsync()
                .Returns(listaFake);

            var lista = await _salaSvc.GetAllAsync();

            Assert.Equal("Cobol", lista.ToList()[3].Nome);
        }
    }
}
