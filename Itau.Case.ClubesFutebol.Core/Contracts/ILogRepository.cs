using Itau.Case.ClubesFutebol.Core.Entities;
using System.Collections.Generic;

namespace Itau.Case.ClubesFutebol.Core.Contracts
{
    public interface ILogRepository
    {
        Log Create(Log clube);
        List<Log> Get();
        Log Get(string id);
        void Remove(Clube clubeIn);
        void Remove(string id);
        void Update(string id, Log clubeIn);
    }
}