using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Case.ClubesFutebol.Application.Views
{
    public class CampeonatoPostViewModel
    {
        /// <summary>
        /// Clubes do campeonato
        /// </summary>
        public ICollection<Pontuacao> Pontuacoes { get; set; }
        /// <summary>
        /// Ano do campeonato
        /// </summary>
        public int Ano { get; set; }
    }
}
