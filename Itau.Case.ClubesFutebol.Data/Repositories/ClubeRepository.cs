using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Data.Repositories
{
    public class ClubeRepository : IClubeRepository
    {
        private readonly IMongoCollection<Clube> _clube;
        public ClubeRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clube = database.GetCollection<Clube>(settings.ClubeCollectionName);
        }
        public List<Clube> Get() =>
                  _clube.Find(clube => true).ToList();

        public Clube Get(string id) =>
            _clube.Find<Clube>(clube => clube.Id == id).FirstOrDefault();

        public List<Clube> GetByEstado(string estado) =>
         _clube.Find<Clube>(clube => clube.Estado == estado).ToList();

        public bool FoneticaExists(string fonetica) =>
      _clube.Find<Clube>(clube => clube.Fonetica == fonetica).Any();
        public List<Clube> GetByTime(string time) =>
            _clube.Find<Clube>(clube => clube.Time.Contains(time)).ToList();

        public Clube Create(Clube clube)
        {
            _clube.InsertOne(clube);
            return clube;
        }
        public void Update(string id, Clube clubeIn) =>
            _clube.ReplaceOne(clube => clube.Id == id, clubeIn);

        public void Remove(Clube clubeIn) =>
            _clube.DeleteOne(clube => clube.Id == clubeIn.Id);

        public void Remove(string id) =>
            _clube.DeleteOne(clube => clube.Id == id);
    }
}
