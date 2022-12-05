using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoAngular.Domain;
using ProjetoAngular.Persistence.Context;

namespace ProjetoAngular.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
      
        private readonly ProjetoAngularContext _context;
        public EventosController(ProjetoAngularContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _context.Evento;
        }
        
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
           return _context.Evento.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
           return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id =  {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
