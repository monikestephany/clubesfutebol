using FluentValidation;
using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Validators
{
    public class CampeonatoValidator : AbstractValidator<Campeonato>
    {
        private readonly PontuacaoValidator pontuacaoValidator;
        public CampeonatoValidator(IClubeRepository clubeRepository)
        {
            this.pontuacaoValidator = new PontuacaoValidator(clubeRepository);
            RuleSet("Novo", () =>
            {
                RuleFor(c => c.Ano).NotEmpty().NotNull().WithMessage("O ano do campeonato é obrigatorio.");
                RuleForEach(p => p.Pontuacoes).SetValidator(pontuacaoValidator).WithErrorCode("Import");
            });
        }
    }
}
