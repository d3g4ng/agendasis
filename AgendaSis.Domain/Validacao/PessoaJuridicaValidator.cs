using AgendaSis.Domain.Entidades;
using FluentValidation;

namespace AgendaSis.Domain.Validacao
{
    public class PessoaJuridicaValidator : AbstractValidator<PessoaJuridica>
    {
        public PessoaJuridicaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O nome da pessoa jurídica deve ser informado")
                .MaximumLength(300).WithMessage("O nome da pessoa jurídica não pode ter mais que 300 caracteres");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("O email da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O email da pessoa jurídica deve ser informado")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(r => r.Cnpj)
                .NotEmpty().WithMessage("O cnpj da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O cnpj da pessoa jurídica deve ser informado")
                .MaximumLength(11).WithMessage("O cnpj da pessoa jurídica não pode ter mais que 11 caracteres");
            RuleFor(r => r.DataAbertura)
                .NotNull().WithMessage("O data de abertura da pessoa jurídica deve ser informada");
            // outras validações omitidas propositalmente
        }
    }
}
