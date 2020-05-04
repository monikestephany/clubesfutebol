using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Entities
{
    public class Log : EntityBase
    {
        /// <summary>
        /// Erro
        /// </summary>
        [BsonElement("mensagem")]
        public string Mensagem { get; set; }
        /// <summary>
        /// Onde aconteceu o erro
        /// </summary>
        [BsonElement("origem")]
        public string Origem { get; set; }
        /// <summary>
        /// Horario do erro
        /// </summary>
        [BsonElement("horario")]
        public DateTime Horario { get; set; }
    }
}
