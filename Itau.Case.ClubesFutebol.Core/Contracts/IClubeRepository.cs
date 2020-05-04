using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface IClubeRepository
    {
        Clube Create(Clube clube);
        List<Clube> Get();
        Clube Get(string id);
        bool FoneticaExists(string fonetica);
        List<Clube> GetByEstado(string estado);
        List<Clube> GetByTime(string time);
        void Remove(Clube clubeIn);
        void Remove(string id);
        void Update(string id, Clube clubeIn);
    }
}
