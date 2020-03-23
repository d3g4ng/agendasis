using AgendaSis.Domain.Interfaces;
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
    public class PessoaFisicaRepositoryTest : BaseContext
    {
        private readonly IPessoaFisicaRepository _repo;

        public PessoaFisicaRepositoryTest()
        {
            PegaContexto();
            _repo = new PessoaFisicaRepository(meuContexto);
        }

        [Theory]
        [InlineData("Andre", "4499999999", "Rua alguma coisa", "email@email.com.br", "097.355.624-21", 1, "20/10/1990")]
        [InlineData("João", "4499999999", "Rua alguma coisa", "email@email.com.br", "937.817.242-39", 1, "20/10/1980")]
        [InlineData("Lucas", "4499999999", "Rua alguma coisa", "email@email.com.br", "476.285.833-18", 1, "20/10/2000")]
        public async Task deve_criar_uma_nova_pf_com_os_dados_corretos(
            string nome,
            string telefone,
            string endereco,
            string email,
            string cpf,
            int generoId,
            string dataNascimentoString
        )
        {
            var dataNascimento = Convert.ToDateTime(dataNascimentoString);

            var pf = new PessoaFisicaBuilder()
                        .ComNome(nome)
                        .ComTelefone(telefone)
                        .ComEndereco(endereco)
                        .ComEmail(email)
                        .ComCpf(cpf)
                        .ComGenero(generoId)
                        .ComDataNascimento(dataNascimento)
                        .Build();

            await _repo.CreateAsync(pf);

            Assert.Equal(1, pf.Id);
        }
    }
}
