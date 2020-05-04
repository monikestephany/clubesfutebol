using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using Itau.Case.ClubesFutebol.Core.Services;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.Services
{
    [TestFixture]
    public class CampeonatoServiceTest
    {
        private Mock<ICampeonatoRepository> campeonatoMock;
        private Mock<IClubeRepository> clubeMock;
        private Mock<ILogRepository> logMock;
        [SetUp]
        public void Setup()
        {
            campeonatoMock = new Mock<ICampeonatoRepository>();
            clubeMock = new Mock<IClubeRepository>();
            logMock = new Mock<ILogRepository>();
        }

        [Test]
        public void CreateTest()
        {
            var campeonato = new Campeonato();
            campeonato.Id = "1";
            campeonato.Ano = 2015;
            campeonato.Pontuacoes = new List<Pontuacao> { new Pontuacao { Estado = "SP", Posicao = "7", Time = "Corinthians", TotalDerrotas = 12, TotalEmpates = 5, TotalVitorias = 13, TotalGolsPros = 28, TotalGolsContras = 16, TotalJogos = 30 } };
            var mock = campeonatoMock.Setup(p => p.Create(campeonato)).Returns(campeonato);
            var service = new CampeonatoService(campeonatoMock.Object, clubeMock.Object, logMock.Object);
            var result = service.Create(campeonato);
            Assert.AreEqual(result.Id, campeonato.Id);
        }
        [Test]
        public void GetByEstadoTest()
        {
            var campeonato = new Campeonato();
            campeonato.Id = "1";
            campeonato.Ano = 2015;
            campeonato.Pontuacoes = new List<Pontuacao> { new Pontuacao { Estado = "SP", Posicao = "7", Time = "Corinthians", TotalDerrotas = 12, TotalEmpates = 5, TotalVitorias = 13, TotalGolsPros = 28, TotalGolsContras = 16, TotalJogos = 30 } };
            var mock = campeonatoMock.Setup(p => p.Get()).Returns(new List<Campeonato> { campeonato });
            var service = new CampeonatoService(campeonatoMock.Object, clubeMock.Object, logMock.Object);
            var result = service.GetByEstado("SP");
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAll()
        {
            var campeonato = new Campeonato();
            campeonato.Id = "1";
            campeonato.Ano = 2015;
            campeonato.Pontuacoes = new List<Pontuacao> { new Pontuacao { Estado = "SP", Posicao = "7", Time = "Corinthians", TotalDerrotas = 12, TotalEmpates = 5, TotalVitorias = 13, TotalGolsPros = 28, TotalGolsContras = 16, TotalJogos = 30 } };
            var mock = campeonatoMock.Setup(p => p.Get()).Returns(new List<Campeonato> { campeonato });
            var service = new CampeonatoService(campeonatoMock.Object, clubeMock.Object, logMock.Object);
            var result = service.GetAll();
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetByTime()
        {
            var campeonato = new Campeonato();
            campeonato.Id = "1";
            campeonato.Ano = 2015;
            campeonato.Pontuacoes = new List<Pontuacao> { new Pontuacao { Estado = "SP", Posicao = "7", Time = "Corinthians", TotalDerrotas = 12, TotalEmpates = 5, TotalVitorias = 13, TotalGolsPros = 28, TotalGolsContras = 16, TotalJogos = 30 } };
            var mock = campeonatoMock.Setup(p => p.Get()).Returns(new List<Campeonato> { campeonato });
            var service = new CampeonatoService(campeonatoMock.Object, clubeMock.Object, logMock.Object);
            var result = service.GetByEstado("Corinthians");
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetInformacoes()
        {
            var campeonato = new Campeonato();
            campeonato.Id = "1";
            campeonato.Ano = 2015;
            campeonato.Pontuacoes = new List<Pontuacao> { new Pontuacao { Estado = "SP", Posicao = "7", Time = "Corinthians", TotalDerrotas = 12, TotalEmpates = 5, TotalVitorias = 13, TotalGolsPros = 28, TotalGolsContras = 16, TotalJogos = 30 } };
            var mock = campeonatoMock.Setup(p => p.Get()).Returns(new List<Campeonato> { campeonato });
            var service = new CampeonatoService(campeonatoMock.Object, clubeMock.Object, logMock.Object);
            var result = service.GetInformacoes();
            Assert.AreEqual(result.MenorNumeroVitorias, "Corinthians");
        }
    }
}
