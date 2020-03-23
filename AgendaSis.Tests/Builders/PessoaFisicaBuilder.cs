using AgendaSis.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Tests.Builders
{
    public class PessoaFisicaBuilder
    {
        private int Id;
        private string Nome;
        private string Telefone;
        private string Endereco;
        private string Email;
        private string Cpf;
        private int GeneroId;
        private DateTime DataNascimento;

        public PessoaFisica Build()
        {
            var pf = new PessoaFisica(
                Nome,
                Telefone,
                Endereco,
                Email,
                Cpf,
                GeneroId,
                DataNascimento
            );

            return pf;
        }

        public PessoaFisicaBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public PessoaFisicaBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PessoaFisicaBuilder ComTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public PessoaFisicaBuilder ComEndereco(string endereco)
        {
            Endereco = endereco;
            return this;
        }

        public PessoaFisicaBuilder ComEmail(string email)
        {
            Email = email;
            return this;
        }

        public PessoaFisicaBuilder ComCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }

        public PessoaFisicaBuilder ComGenero(int generoId)
        {
            GeneroId = generoId;
            return this;
        }

        public PessoaFisicaBuilder ComDataNascimento(DateTime date)
        {
            DataNascimento = date;
            return this;
        }
    }
}
