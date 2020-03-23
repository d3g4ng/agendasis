using AgendaSis.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgendaSis.Tests.Implementations.Domain.Entidades
{

    public class PessoaFisicaTest
    {
        [Theory]
        [InlineData("Andre", "4499999999","Rua alguma coisa", "email@email.com.br", "097.355.624-21", 1, "20/10/1990")]
        [InlineData("João", "4499999999", "Rua alguma coisa", "email@email.com.br", "937.817.242-39", 1, "20/10/1980")]
        [InlineData("Lucas", "4499999999", "Rua alguma coisa", "email@email.com.br", "476.285.833-18", 1, "20/10/2000")]
        public async Task deve_validar_novo_objeto_de_pf(
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

            var pf = new PessoaFisica(nome, telefone, endereco, email, cpf, generoId, dataNascimento);

            var validator = await pf.Validate();

            Assert.True(validator.IsValid);
        }

        [Theory]
        [InlineData("Andre", "4499999999", "Rua alguma coisa", "email@email.com.br", "097.375.624-21", 1, "20/10/1990")]
        [InlineData("João", "4499999999", "Rua alguma coisa", "email@email.com.br", "937.813.242-39", 1, "20/10/1980")]
        [InlineData("Lucas", "4499999999", "Rua alguma coisa", "email@email.com.br", "476.235.833-18", 1, "20/10/2000")]
        public async Task deve_validar_novo_objeto_de_pf_com_cpf_invalido(
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

            var pf = new PessoaFisica(nome, telefone, endereco, email, cpf, generoId, dataNascimento);

            var validator = await pf.Validate();

            Assert.False(validator.IsValid);
        }
    }
}
