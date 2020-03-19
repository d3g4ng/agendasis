using AgendaSis.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Tests.Builders
{
    public class SalaBuilder
    {
        private int Id;
        private string Nome;
        private int Capacidade;
        private int Andar;

        public Sala Build()
        {
            var sala = new Sala(Nome, Capacidade, Andar);
            sala.SetaId(Id);

            return sala;
        }

        public SalaBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public SalaBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public SalaBuilder ComCapacidade(int capacidade)
        {
            Capacidade = capacidade;
            return this;
        }

        public SalaBuilder ComAndar(int andar)
        {
            Andar = andar;
            return this;
        }
    }
}
