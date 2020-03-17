using AgendaSis.Domain.Entidades;
using FluentValidation;

namespace AgendaSis.Domain.Validacao
{
    public class PessoaFisicaValidator : AbstractValidator<PessoaFisica>
    {
        public PessoaFisicaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome da pessoa física deve ser informado")
                .NotNull().WithMessage("O nome da pessoa física deve ser informado")
                .MaximumLength(300).WithMessage("O nome da pessoa física não pode ter mais que 300 caracteres");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("O email da pessoa física deve ser informado")
                .NotNull().WithMessage("O email da pessoa física deve ser informado")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(r => r.Cpf)
                .NotEmpty().WithMessage("O cpf da pessoa física deve ser informado")
                .NotNull().WithMessage("O cpf da pessoa física deve ser informado")
                .MaximumLength(11).WithMessage("O cpf da pessoa física não pode ter mais que 11 caracteres");
            RuleFor(r => r.DataNascimento)
                .NotNull().WithMessage("O data de nascimento da pessoa física deve ser informada");
            RuleFor(r => r.GeneroId)
                .NotNull().WithMessage("O genero da pessoa física deve ser informado")
                .GreaterThan(0).WithMessage("O genero informado é inválido");
            // outras validações omitidas propositalmente
        }
    }
}
