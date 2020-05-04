using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itau.Case.ClubesFutebol.Data.Repositories
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly IMongoCollection<Campeonato> _campeonato;
        public CampeonatoRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _campeonato = database.GetCollection<Campeonato>(settings.CampeonatoCollectionName);
        }
        public List<Campeonato> Get() =>
                  _campeonato.Find(clube => true).ToList();

        public Campeonato Get(string id) =>
            _campeonato.Find<Campeonato>(clube => clube.Id == id).FirstOrDefault();

        public Campeonato Create(Campeonato campeonato)
        {
            _campeonato.InsertOne(campeonato);
            return campeonato;
        }
        public List<Campeonato> CreateAll(List<Campeonato> campeonatos)
        {
            _campeonato.InsertMany(campeonatos);
            return campeonatos;
        }
        public void Update(string id, Campeonato campeonatoIn) =>
            _campeonato.ReplaceOne(clube => clube.Id == id, campeonatoIn);

        public void Remove(Campeonato campeonatoIn) =>
            _campeonato.DeleteOne(campeonato => campeonato.Id == campeonatoIn.Id);

        public void Remove(string id) =>
            _campeonato.DeleteOne(campeonato => campeonato.Id == id);
    }
}

