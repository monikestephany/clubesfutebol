using Itau.Case.ClubesFutebol.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Case.ClubesFutebol.Core.Dtos
{
    public class DBClubeSettings : IDBClubeSettings
    {
        public string ClubeCollectionName { get; set; }
        public string LogCollectionName { get; set; }
        public string CampeonatoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
