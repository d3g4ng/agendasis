using AgendaSis.Domain.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Domain.Validacao
{
    public class AgendaValidator : AbstractValidator<Agenda>
    {
        public AgendaValidator()
        {
            RuleFor(r => r.Data)
                .NotNull().WithMessage("A data do agendamento deve ser informada");
            RuleFor(r => r.HoraInicio)
                .NotEmpty().WithMessage("A hora de início do agendamento deve ser informada")
                .NotNull().WithMessage("A hora de início do agendamento deve ser informada");
            RuleFor(r => r.HoraFim)
                .NotEmpty().WithMessage("A hora do fim do agendamento deve ser informada")
                .NotNull().WithMessage("A hora do fim do agendamento deve ser informada");
            RuleFor(r => r.QuantidadePessoas)
               .NotNull().WithMessage("A quantidade de pessoas deve ser informada");
            RuleFor(r => r.SalaId)
                .NotNull().WithMessage("A sala deve ser informada")
                .GreaterThan(0).WithMessage("A sala informada é inválida");
            RuleFor(r => r.PessoaId)
                .NotNull().WithMessage("A pessoa deve ser informada")
                .GreaterThan(0).WithMessage("A pessoa informada é inválida");
            // outras validações omitidas propositalmente
        }
    }
}
