using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAngular.Application.Contracts;
using ProjetoAngular.Domain;
using ProjetoAngular.Persistence.Context;

namespace ProjetoAngular.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
      
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
            var evento = await _eventoService.GetAllEventosAsync(true);

            if (evento == null) 
            {
                return NotFound("Nenhum evento encontrado!");
            }

            return Ok(evento);

           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. Erro: {ex.Message}");
           }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           try
           {
            var evento = await _eventoService.GetEventoByIdAsync(id);

            if (evento == null) 
            {
                return NotFound("Nenhum evento encontrado!");
            }

            return Ok(evento);

           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. Erro: {ex.Message}");
           }
        }

         [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
           try
           {
            var evento = await _eventoService.GetAllEventosByTemaAsync(tema);

            if (evento == null) 
            {
                return NotFound("Nenhum evento por tema encontrado!");
            }

            return Ok(evento);

           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. Erro: {ex.Message}");
           }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
            var evento = await _eventoService.AddEvento(model);

            if (evento == null) 
            {
                return BadRequest("Erro ao tentar adicionar evento!");
            }

            return Ok(evento);

           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Eventos. Erro: {ex.Message}");
           }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
            var evento = await _eventoService.UpdateEvento(id, model);

            if (evento == null) 
            {
                return BadRequest("Erro ao tentar atualizar evento!");
            }

            return Ok(evento);

           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar Eventos. Erro: {ex.Message}");
           }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await  _eventoService.DeleteEvento(id))
                    return Ok("Deletado!");
                else
                  return BadRequest("Evento não deletado!");
            
           }
           catch (Exception ex)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. Erro: {ex.Message}");
           }
        }
    }
}
