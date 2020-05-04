using FluentValidation;
using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Validators
{
    public class PontuacaoValidator : AbstractValidator<Pontuacao>
    {
        private readonly IClubeRepository clubeRepository;
        public PontuacaoValidator(IClubeRepository clubeRepository)
        {
            this.clubeRepository = clubeRepository;

            RuleFor(p => p.Time).NotNull().NotEmpty().WithMessage("O Time do campeonato é obrigatorio.")
                .Must(FoneticaTimeExiste).WithMessage("Time não encontrado.");
        }
        private bool FoneticaTimeExiste(string time)
        {
            string fonetica = Fonetica.Fonetiza(time);
            return clubeRepository.FoneticaExists(fonetica);
        }
    }
}
