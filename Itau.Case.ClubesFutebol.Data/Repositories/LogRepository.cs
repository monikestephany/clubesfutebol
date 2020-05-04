using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _log;
        public LogRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _log = database.GetCollection<Log>(settings.LogCollectionName);
        }
        public List<Log> Get() =>
                  _log.Find(clube => true).ToList();

        public Log Get(string id) =>
            _log.Find<Log>(clube => clube.Id == id).FirstOrDefault();

        public Log Create(Log clube)
        {
            _log.InsertOne(clube);
            return clube;
        }
        public void Update(string id, Log clubeIn) =>
            _log.ReplaceOne(clube => clube.Id == id, clubeIn);

        public void Remove(Clube clubeIn) =>
            _log.DeleteOne(clube => clube.Id == clubeIn.Id);

        public void Remove(string id) =>
            _log.DeleteOne(clube => clube.Id == id);
    }
}
