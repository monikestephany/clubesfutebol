using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface ICampeonatoService
    {
        List<Campeonato> Import(List<string> arquivo);
        Campeonato Create(Campeonato campeonato);
        List<Campeonato> GetByEstado(string estado);
        List<Campeonato> GetByTime(string time);
        List<Campeonato> GetAll();
        Informacoes GetInformacoes();
    }
}
