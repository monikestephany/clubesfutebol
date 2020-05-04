using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Case.ClubesFutebol.Application.Views
{
    public class CampeonatoTimeViewModel
    {
        /// <summary>
        /// Nome do Clube
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// Posicao do Clube
        /// </summary>
        public string Posicao { get; set; }
        /// <summary>
        /// Total de Jogos
        /// </summary>
        public decimal TotalJogos { get; set; }
        /// <summary>
        /// Total de Vitorias
        /// </summary>
        public decimal TotalVitorias { get; set; }
        /// <summary>
        /// Total de Empates
        /// </summary>
        public decimal TotalEmpates { get; set; }
        /// <summary>
        /// Total de Derrotas
        /// </summary>
        public decimal TotalDerrotas { get; set; }
        /// <summary>
        /// Total de Gols Pros
        /// </summary>
        public decimal TotalGolsPros { get; set; }
        /// <summary>
        /// Total de Gols Contras
        /// </summary>
        public decimal TotalGolsContras { get; set; }
        /// <summary>
        /// Saldo de gols 
        /// </summary>
        public decimal SaldoGols { get; set; }
        /// <summary>
        /// Quantidade de campeonatos 
        /// </summary>
        public decimal QtdCampeonatos { get; set; }
        /// <summary>
        /// Pontuacao total
        /// </summary>
        public decimal PontuacaoTotal { get; set; }
    }
}
