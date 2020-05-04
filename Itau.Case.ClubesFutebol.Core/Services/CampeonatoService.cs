using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using Itau.Case.ClubesFutebol.Core.Validators;
using System.Collections.Generic;
using FluentValidation;
using System;
using System.Linq;
using System.Text;

namespace Itau.Case.ClubesFutebol.Core.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly CampeonatoValidator validator;
        private readonly ICampeonatoRepository campeonatoRepository;
        private readonly ILogRepository logRepository;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository, IClubeRepository clubeRepository, ILogRepository logRepository)
        {
            this.campeonatoRepository = campeonatoRepository;
            validator = new CampeonatoValidator(clubeRepository);
            this.logRepository = logRepository;
        }
        public Campeonato Create(Campeonato campeonato)
        {
            return campeonatoRepository.Create(campeonato);
        }
        public List<Campeonato> Import(List<string> arquivo)
        {
            //Ler arquivo
            var campeonatos = new List<Campeonato>();
            for (int i = 0; i < arquivo.Count; i++)
            {
                var campeonato = new Campeonato();
                campeonato.Ano = int.Parse(arquivo[i].Substring(0, 4));
                campeonato.Pontuacoes = new List<Pontuacao>();
                i += 5;
                for (int j = 0; j < 20; j++)
                {
                    var clube = new Pontuacao();
                    campeonato.Pontuacoes.Add(clube.ConverterStringParaClube(arquivo[i]));
                    i++;
                }
                campeonatos.Add(campeonato);
            }
            //Incluir Dados
            foreach (var item in campeonatos)
            {
                var result = validator.Validate(item, ruleSet: "Novo");
                if(!result.IsValid)
                {
                    foreach (var erro in result.Errors)
                    {
                        if (erro.ErrorCode == "Import")
                        {
                            campeonatos.Remove(item);
                        }

                        logRepository.Create(new Log { Mensagem = erro.ErrorMessage, Origem = "Importação", Horario = DateTime.Now });
                    }
                }
            }
            return campeonatoRepository.CreateAll(campeonatos);
        }
        public List<Campeonato> GetByEstado(string estado)
        {
            var list = campeonatoRepository.Get();
            foreach (var item in list)
            {
                item.Pontuacoes = item.Pontuacoes.Where(p => p.Estado == estado).ToList();
            }
            return list;
        }
        public List<Campeonato> GetAll()
        {
            return campeonatoRepository.Get();
        }
        public List<Campeonato> GetByTime(string time)
        {
            var list = campeonatoRepository.Get();
            foreach (var item in list)
            {
                item.Pontuacoes = item.Pontuacoes.Where(p => p.Time == time).ToList();
            }
            return list;
        }
        public Informacoes GetInformacoes()
        {
            var times = AgruparPorTime();
            var info = new Informacoes(times);
            return info;
        }
        private Dictionary<string, List<Pontuacao>> AgruparPorTime()
        {
            var list = campeonatoRepository.Get();
            var listPontuacoes = new Dictionary<string, List<Pontuacao>>();
            //Agrupar por times
            foreach (var item in list)
            {
                var dic = item.Pontuacoes.GroupBy(p => p.Time).ToDictionary(p => p.Key, p => p.ToList());
                foreach (var d in dic)
                {
                    if (listPontuacoes.ContainsKey(d.Key))
                    {
                        listPontuacoes.GetValueOrDefault(d.Key).AddRange(d.Value);
                    }
                    else
                    {
                        listPontuacoes.Add(d.Key, d.Value);
                    }
                }
            }      
            return listPontuacoes;
        }
    }
}
