using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface IDBClubeSettings
    {
        string ClubeCollectionName { get; set; }
        string LogCollectionName { get; set; }
        string CampeonatoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
