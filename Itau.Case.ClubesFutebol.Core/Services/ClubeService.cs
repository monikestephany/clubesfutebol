using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Services
{
    public class ClubeService : IClubeService
    {
        private readonly IClubeRepository clubeRepository;

        public ClubeService(IClubeRepository clubeRepository)
        {
            this.clubeRepository = clubeRepository;
        }
        public List<Clube> GetAll()
        {
            return clubeRepository.Get();
        }
        public List<Clube> GetByTime(string time)
        {
            return clubeRepository.GetByTime(time);
        }
        public List<Clube> GetByEstado(string estado)
        {
            return clubeRepository.GetByEstado(estado);
        }
        public Clube Create(Clube clube)
        {
            //gerar fonetica
            clube.Fonetica = Fonetica.Fonetiza(clube.Time);
            return clubeRepository.Create(clube);
        }
    }
}
