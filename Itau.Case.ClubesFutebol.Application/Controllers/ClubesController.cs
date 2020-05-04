using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Itau.Case.ClubesFutebol.Application.Views;
using Itau.Case.ClubesFutebol.Core.Contracts;
using Itau.Case.ClubesFutebol.Core.Entities;
using Itau.Case.ClubesFutebol.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Itau.Case.ClubesFutebol.Application.Controllers
{
    [Route("api/clubes")]
    [ApiController]
    public class ClubesController : ControllerBase
    {    
        private readonly IClubeService clubeService;
        private readonly IMapper mapper;
        private readonly ILogger<ClubesController> logger;
        public ClubesController(IClubeService clubeService, IMapper mapper, ILogger<ClubesController> logger)
        {
            this.clubeService = clubeService;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(clubeService.GetAll());
            }
            catch (Exception ex) 
            {
                logger.LogError("Get", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na busca.");
            }
        }

        [HttpGet("buscar-time")]
        public IActionResult GetByTime(string time)
        {
            try
            {
                return Ok(clubeService.GetByTime(time));
            }
            catch (Exception ex)
            {
                logger.LogError("GetByTime", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na busca por time.");
            }
        }
        [HttpGet("buscar-estado")]
        public IActionResult GetByEstado(string estado)
        {
            try
            {
                return Ok(clubeService.GetByEstado(estado));
            }
            catch (Exception ex)
            {
                logger.LogError("GetByEstado", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na busca por estado.");
            }
        }
        [HttpPost]
        public ActionResult<Clube> Create(ClubePostViewsModel clube)
        {
            try
            {
                return Created("Post", clubeService.Create(mapper.Map<Clube>(clube)));
            }
            catch (Exception ex)
            {
                logger.LogError("Create", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha criação.");
            }
        }
    }
}