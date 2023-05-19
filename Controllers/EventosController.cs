using DevEvents.API.Entities;
using DevEvents.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JornadaDotNet.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly EventosDbContext _context;
        public EventosController(EventosDbContext context)
        {
            _context = context;
        }

        //GET api/eventos 
        [HttpGet]
        public IActionResult GetAll()
        {
            var eventos = _context.Eventos;

            return Ok(eventos);
        }

        // GET api/eventos 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        // POST api/eventos 
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();

            // Já retorna a url de onde eu posso acessar o objeto que foi criado. 
            return CreatedAtAction(nameof(GetById), new { Id = evento.Id }, evento);
        }

        // PUT api/eventos/1 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento evento)
        {
            var eventoExistente = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if (eventoExistente == null)
                return NotFound();

            eventoExistente.Update(evento.Titulo, evento.Descricao, evento.DataInicio, evento.DataFim);
            _context.Eventos.Update(eventoExistente);            
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/eventos/1 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);

            if(evento == null)
                return NotFound(); 

            _context.Eventos.Remove(evento);
            _context.SaveChanges();

            return NoContent();
        }
    }
}