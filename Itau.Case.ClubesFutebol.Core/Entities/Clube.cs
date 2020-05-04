using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Entities
{
    public class Clube : EntityBase
    {
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
        /// Nome fonetica do clube
        /// </summary>
        [BsonElement("fonetica")]
        public string Fonetica { get; set; }
    }
}
