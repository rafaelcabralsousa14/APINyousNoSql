using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NyousAPINoSql.Domains;
using NyousAPINoSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NyousAPINoSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly iEventoRepository _eventoRepository;

        public EventoController(iEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpPost]
        public ActionResult<EventoDomain> Create(EventoDomain evento)
        {
            _eventoRepository.Adicionar(evento);
            return Ok(evento);
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            return _eventoRepository.Listar();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _eventoRepository.Remover(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento)
        {
            evento.Id = id;
            _eventoRepository.Atualizar(id, evento);
            return Ok();
        }
    }
}
