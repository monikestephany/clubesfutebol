using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface ICampeonatoRepository
    {
        Campeonato Create(Campeonato campeonato);
        List<Campeonato> CreateAll(List<Campeonato> campeonatos);
        List<Campeonato> Get();
        Campeonato Get(string id);
        void Remove(Campeonato campeonatoIn);
        void Remove(string id);
        void Update(string id, Campeonato campeonatoIn);
    }
}
