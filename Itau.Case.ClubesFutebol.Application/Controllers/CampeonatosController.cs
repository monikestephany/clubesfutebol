using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itau.Case.ClubesFutebol.Application.Views;
using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Core.Entities.Dtos;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Itau.Case.ClubesFutebol.Application.Controllers
{
    [Route("api/campeonatos")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private readonly ICampeonatoService campeonatoService;
        private readonly IMapper mapper;
        private readonly ILogger<CampeonatosController> logger;
        public CampeonatosController(ICampeonatoService campeonatoService, IMapper mapper, ILogger<CampeonatosController> logger)
        {
            this.campeonatoService = campeonatoService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost("importar")]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                return Ok(campeonatoService.Import(FilesMethods.ReadFile(file)));
            }
            catch (Exception ex)
            {
                logger.LogError("Import", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na importação.");
            }
            
        }
        [HttpPost]
        public ActionResult<Campeonato> Create(CampeonatoPostViewModel campeonato)
        {
            try 
            { 
                 return Created("Post",campeonatoService.Create(mapper.Map<Campeonato>(campeonato)));
            }
            catch (Exception ex)
            {
                logger.LogError("Create", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na criação do campeonato.");
            }
        }
        [HttpGet("buscar-estado")]
        public ActionResult<Campeonato> GetByEstado(string estado)
        {
            try
            {
                var result = mapper.Map<List<CampeonatoTimeViewModel>>(campeonatoService.GetByEstado(estado));
                result.ForEach(p => p.QtdCampeonatos = result.Count);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError("GetByEstado", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na consulta por estado.");
            }
        }
        [HttpGet("buscar-time")]
        public ActionResult<Campeonato> GetByTime(string time)
        {
            try
            {
                var result = mapper.Map<List<CampeonatoTimeViewModel>>(campeonatoService.GetByTime(time));
                result.ForEach(p => p.QtdCampeonatos = result.Count);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError("GetByTime", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na consulta por time.");
            }
        }
        [HttpGet("buscar-informacoes-complementares")]
        public ActionResult<Informacoes> GetInfomacoesComplementares()
        {
            try
            {
                var result = campeonatoService.GetInformacoes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError("GetInfomacoesComplementares", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na consulta por time.");
            }
        }
    }
}