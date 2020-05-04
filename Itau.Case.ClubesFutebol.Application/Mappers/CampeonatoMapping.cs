using AutoMapper;
using Itau.Case.ClubesFutebol.Application.Views;
using Itau.Case.ClubesFutebol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Case.ClubesFutebol.Application.Mappers
{
    public class CampeonatoMapping : Profile
    {
        public CampeonatoMapping()
        {
            CreateMap<CampeonatoTimeViewModel, Campeonato>();
            CreateMap<Campeonato, CampeonatoTimeViewModel>()
                .AfterMap((src, dest) =>
                {
                    foreach (var item in src.Pontuacoes)
                    {
                        dest.Posicao = item.Posicao;
                        dest.Time = item.Time;
                        dest.TotalVitorias = item.TotalVitorias;
                        dest.TotalJogos = item.TotalJogos;
                        dest.TotalEmpates = item.TotalEmpates;
                        dest.TotalDerrotas = item.TotalDerrotas;
                        dest.TotalGolsPros = item.TotalGolsPros;
                        dest.TotalGolsContras = item.TotalGolsContras;
                        dest.SaldoGols = item.TotalGolsPros - item.TotalGolsContras;
                        dest.PontuacaoTotal = (item.TotalVitorias + item.TotalEmpates) - item.TotalDerrotas;
                    }
                });

            CreateMap<Campeonato, CampeonatoEstadoViewModel>()
              .AfterMap((src, dest) =>
              {
                  foreach (var item in src.Pontuacoes)
                  {
                      dest.Posicao = item.Posicao;
                      dest.Estado = item.Estado;
                      dest.TotalVitorias = item.TotalVitorias;
                      dest.TotalJogos = item.TotalJogos;
                      dest.TotalEmpates = item.TotalEmpates;
                      dest.TotalDerrotas = item.TotalDerrotas;
                      dest.TotalGolsPros = item.TotalGolsPros;
                      dest.TotalGolsContras = item.TotalGolsContras;
                      dest.SaldoGols = item.TotalGolsPros - item.TotalGolsContras;
                      dest.PontuacaoTotal = (item.TotalVitorias + item.TotalEmpates) - item.TotalDerrotas;
                  }
              });
        }
    }
}
