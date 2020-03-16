using AgendaSis.Application.Models.Generos;
using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Pessoas
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _repo;

        public PessoaFisicaService(IPessoaFisicaRepository repo)
        {
            _repo = repo;
        }

        public async Task<PessoaFisicaResponseDto> CreateAsync(PessoaFisicaRequestDto model)
        {
            var pessoa = new PessoaFisica(
                model.Nome,
                model.Telefone,
                model.Endereco,
                model.Email,
                model.Cpf,
                model.GeneroId,
                model.DataNascimento
            );

            await _repo.CreateAsync(pessoa);

            return new PessoaFisicaResponseDto {
                Id = pessoa.Id,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                GeneroId = pessoa.GeneroId
            };
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PessoaFisicaResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaResponseDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, PessoaFisicaRequestDto model)
        {
            var pessoa = await _repo.GetByIdAsync(id);

            if (pessoa == null)
            {
                throw new Exception($"Pessoa Física com o id {id} não encontrada");
            }

            pessoa.UpdateValues(
                model.Nome,
                model.Telefone,
                model.Endereco,
                model.Email,
                model.Cpf,
                model.GeneroId,
                model.DataNascimento
            );

            await _repo.UpdateAsync(pessoa);
        }
    }
}
