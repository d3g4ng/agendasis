using AgendaSis.Application.Models.Salas;
using AgendaSis.Application.Services.Salas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Tests.Builders;
using NSubstitute;
using System;
using System.Collections.Generic;
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

            await _salaSvc.CreateAsync(salaDto);

            await _salaRepo
                .Received(1)
                .CreateAsync(Arg.Is<Sala>(d =>
                    d.Nome == salaDto.Nome &&
                    d.Andar == salaDto.Andar && 
                    d.Capacidade == salaDto.Capacidade
                ));
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
    }
}
