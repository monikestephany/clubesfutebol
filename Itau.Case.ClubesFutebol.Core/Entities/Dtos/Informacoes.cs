using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Entities.Dtos
{
    public class Informacoes
    {
        public Informacoes(Dictionary<string, List<Pontuacao>> times)
        {
            MelhorMaiorMediaGols = MelhorMediaGolsPro(times).ToString();
            MelhorMenorMediaGolsContra = MelhorMediaGolsContra(times).ToString();
            MaiorNumerosVitoria = MaiorNumeroVitorias(times).ToString();
            MenorNumeroVitorias = MenorNumerosVitorias(times).ToString();
            MelhorMediaVitorias = MelhorMediaVitoriasCampeonato(times).ToString();
            MenorMediaVitorias = MenorMediaVitoriasCampeonato(times).ToString();
        }

        public string MelhorMaiorMediaGols { get; set; }
        public string MelhorMenorMediaGolsContra { get; set; }
        public string MaiorNumerosVitoria { get; set; }
        public string MenorNumeroVitorias { get; set; }
        public string MelhorMediaVitorias { get; set; }
        public string MenorMediaVitorias { get; set; }

        public StringBuilder MelhorMediaGolsPro(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalGolsPros, p.TotalJogos });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), val.Sum(p => p.TotalGolsPros) / val.Sum(p => p.TotalJogos));
            }
            var result = list.Max(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }
        public StringBuilder MaiorNumeroVitorias(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalVitorias });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), val.Sum(p => p.TotalVitorias));
            }
            var result = list.Max(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }
        public StringBuilder MenorNumerosVitorias(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalVitorias });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), val.Sum(p => p.TotalVitorias));
            }
            var result = list.Min(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }
        public StringBuilder MelhorMediaGolsContra(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalGolsContras, p.TotalJogos });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), (val.Sum(p => p.TotalGolsContras) / val.Sum(p => p.TotalJogos)));
            }
            var result = list.Min(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }
        public StringBuilder MelhorMediaVitoriasCampeonato(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalVitorias });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), (val.Sum(p => p.TotalVitorias) / times.Count));
            }
            var result = list.Max(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }

        public StringBuilder MenorMediaVitoriasCampeonato(Dictionary<string, List<Pontuacao>> times)
        {
            var text = new StringBuilder();
            var list = new Dictionary<string, decimal>();
            foreach (var item in times)
            {
                var val = item.Value.Select(p => new { p.Time, p.TotalVitorias });
                list.Add(val.Select(p => p.Time).FirstOrDefault(), (val.Sum(p => p.TotalVitorias) / times.Count));
            }
            var result = list.Min(p => p.Value);
            return text.AppendJoin(',', list.Where(p => p.Value == result).Select(p => p.Key).ToList());
        }
    }
}
