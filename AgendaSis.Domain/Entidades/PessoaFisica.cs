using System;

namespace AgendaSis.Domain.Entidades
{
    public class PessoaFisica : Pessoa
    {
        protected PessoaFisica() { }

        public PessoaFisica(
            string nome, 
            string telefone, 
            string endereco, 
            string email, 
            string cpf, 
            int generoId, 
            DateTime dataNascimento
        )
            : base (nome, telefone, endereco, email)
        {
            Cpf = cpf;
            GeneroId = generoId;
            DataNascimento = dataNascimento;
        }

        public void UpdateValues(
            string nome,
            string telefone,
            string endereco,
            string email,
            string cpf,
            int generoId,
            DateTime dataNascimento
        )
        {
            UpdateValues(nome, telefone, endereco, email);
            Cpf = cpf;
            GeneroId = generoId;
            DataNascimento = dataNascimento;
        }

        public string Cpf { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public int GeneroId { get; protected set; }

        public virtual Genero Genero { get; protected set; }
    }
}
