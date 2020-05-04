using Itau.Case.ClubesFutebol.Core.Entities.Enum;
using Itau.Case.ClubesFutebol.Infrastructure.Extensions;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Entities.Dtos
{
    public class Pontuacao 
    {
        #region Properties
        /// <summary>
        /// Nome do Clube
        /// </summary>
        [BsonElement("time")]
        public string Time { get; set; }
        /// <summary>
        /// Estado do clube
        /// </summary>
        [BsonElement("estado")]
        public string Estado { get; set; }
        /// <summary>
        /// Posicao do Clube
        /// </summary>
        [BsonElement("posicao")]
        public string Posicao { get; set; }
        /// <summary>
        /// Total de Jogos
        /// </summary>
        [BsonElement("total_jogos")]
        public decimal TotalJogos { get; set; }
        /// <summary>
        /// Total de Vitorias
        /// </summary>
        [BsonElement("total_vitorias")]
        public decimal TotalVitorias { get; set; }
        /// <summary>
        /// Total de Empates
        /// </summary>
        [BsonElement("total_empates")]
        public decimal TotalEmpates { get; set; }
        /// <summary>
        /// Total de Derrotas
        /// </summary>
        [BsonElement("total_derrotas")]
        public int TotalDerrotas { get; set; }
        /// <summary>
        /// Total de Gols Pros
        /// </summary>
        [BsonElement("total_gols_pros")]
        public decimal TotalGolsPros { get; set; }
        /// <summary>
        /// Total de Gols Contras
        /// </summary>
        [BsonElement("total_gols_contras")]
        public decimal TotalGolsContras { get; set; }
        #endregion
        #region Methods
        public Pontuacao ConverterStringParaClube(string arquivo)
        {
            var clube = new Pontuacao();
            string[] parts = arquivo.Split('\t');
            parts = parts.Where(p => !string.IsNullOrEmpty(p)).ToArray();
            clube.Time = parts[1].FormatString();
            clube.Estado = parts[2].FormatString();
            clube.Posicao = parts[3].FormatString();
            clube.TotalJogos = int.Parse(parts[4].FormatString());
            clube.TotalVitorias = int.Parse(parts[5].FormatString());
            clube.TotalEmpates = int.Parse(parts[6].FormatString());
            clube.TotalDerrotas = int.Parse(parts[7].FormatString());
            clube.TotalGolsPros = int.Parse(parts[8].FormatString());
            clube.TotalGolsContras = int.Parse(parts[9].FormatString());
            return clube;
        }
        #endregion
    }
}
