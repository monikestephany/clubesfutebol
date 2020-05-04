using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface IClubeService
    {
        List<Clube> GetAll();
        List<Clube> GetByTime(string time);
        List<Clube> GetByEstado(string estado);
        Clube Create(Clube clube);
    }
}
