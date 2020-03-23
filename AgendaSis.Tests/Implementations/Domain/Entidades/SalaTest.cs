using AgendaSis.Domain.Entidades;
using AgendaSis.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgendaSis.Tests.Implementations.Domain.Entidades
{
    public class SalaTest
    {
        [Fact]
        public void deve_atualizar_os_valores_da_instancia_da_sala()
        {
            var sala = new SalaBuilder()
                                .ComId(2)
                                .ComNome("Cobol")
                                .ComCapacidade(6)
                                .ComAndar(5)
                                .Build();

            var nome = "Python";
            var capacidade = 7;
            var andar = 4;

            sala.ChangeValues(nome, capacidade, andar);

            Assert.Equal(nome, sala.Nome);
            Assert.Equal(capacidade, sala.Capacidade);
            Assert.Equal(andar, sala.Andar);
            Assert.Equal(2, sala.Id);
        }

        [Theory]
        [InlineData("Cobol")]
        [InlineData("Python")]
        [InlineData("DC")]
        [InlineData("Marvel")]
        public async Task deve_validar_nome_correto(string nome)
        {
            var sala = new SalaBuilder()
                                .ComId(2)
                                .ComNome(nome)
                                .ComCapacidade(6)
                                .ComAndar(5)
                                .Build();

            var validator = await sala.Validate();

            Assert.True(validator.IsValid);
        }

        [Theory]
        [InlineData(null, "NotEmpty", "O nome da sala não pode ser vazia")]
        [InlineData("", "NotEmpty", "O nome da sala não pode ser vazia")]
        [InlineData("devevalidarumnomedesalacommaisdetresentoscaracteres_devevalidarumnomedesalacommaisdetresentoscaracteres_devevalidarumnomedesalacommaisdetresentoscaracteres_devevalidarumnomedesalacommaisdetresentoscaracteres_devevalidarumnomedesalacommaisdetresentoscaracteres_devevalidarumnomedesalacommaisdetresentoscaracteres_", "MaximumLength", "O nome da sala não pode ter mais que 300 caracteres")]
        public async Task deve_validar_nome_incorreto(string nome, string codeError, string erroMsg)
        {
            var sala = new SalaBuilder()
                                .ComId(2)
                                .ComNome(nome)
                                .ComCapacidade(6)
                                .ComAndar(5)
                                .Build();

            var validator = await sala.Validate();

            Assert.False(validator.IsValid);
            Assert.Equal(codeError, validator.Errors[0].ErrorCode);
            Assert.Equal(erroMsg, validator.Errors[0].ErrorMessage);
        }

        [Theory]
        [InlineData("", 0, 0)]
        public async Task deve_validar_dados_incorretos_da_sala(string nome, int capacidade, int andar)
        {
            var sala = new Sala(nome, capacidade, andar);

            var validator = await sala.Validate();

            Assert.False(validator.IsValid);
        }
    }
}
