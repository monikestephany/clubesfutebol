using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Entities
{
    public class Campeonato : EntityBase
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
