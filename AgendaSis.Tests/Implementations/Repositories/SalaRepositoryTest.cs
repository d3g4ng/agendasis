using AgendaSis.Infra.Contexto;
using AgendaSis.Infra.Repositorios;
using AgendaSis.Tests.Builders;
using AgendaSis.Tests.Implementations.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgendaSis.Tests.Implementations.Repositories
{
    public class SalaRepositoryTest : BaseContext
    {
        private readonly SalaRepository _salaRepo;

        public SalaRepositoryTest()
        {
            PegaContexto();
            _salaRepo = new SalaRepository(meuContexto);
        }

        [Fact]
        public async Task deve_criar_uma_nova_sala()
        {
            var sala = new SalaBuilder()
                                .ComNome("Cobol")
                                .ComCapacidade(6)
                                .ComAndar(5)
                                .Build();

            await _salaRepo.CreateAsync(sala);

            Assert.Equal(1, sala.Id);
        }
    }
}
