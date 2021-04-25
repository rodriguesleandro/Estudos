using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using ProEventos.Domain;

using ProEventos.Application.Contratos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventosController : ControllerBase
    {
        // private IEnumerable<Evento> _eventos = new Evento[]{
        //     new Evento(){
        //         EventoId = 1,
        //         Tema = "Angular",
        //         Local = "BH",
        //         Lote = "Primeiro",
        //         QtdPessoas = 250,
        //         DataEvento = DateTime.Now.AddDays(2).ToString()
        //     },
        //     new Evento()
        //     {
        //         EventoId = 2,
        //         Tema = "Ionic",
        //         Local = "SP",
        //         Lote = "Primeiro",
        //         QtdPessoas = 350,
        //         DataEvento = DateTime.Now.AddDays(1).ToString()
        //     }};
        
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;     
        }

        /// <summary>Retorna todos os Eventos.</summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //await Task.Delay(1000);
                //throw new Exception("Zoeira Never Ends!");
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum Evento Encontrado!");

                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar esta porra -> {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id,true);
                if(evento == null) return NotFound("Nenhum Evento Encontrado!");

                return Ok(evento);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar esta porra por ID -> {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema,true);
                if(eventos == null) return NotFound("Nenhum Eventos por tema não Encontrado!");

                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar esta porra por Tema -> {ex.Message}");
            }
        }

        [HttpPost]
        public async  Task<IActionResult> Post(Evento model)
        {
            try
            {
                var eventos = await _eventoService.AddEvento(model);
                if(eventos == null) return BadRequest("Falha na inserção");

                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(500, $"Erro ao tentar adicionar esta porra -> {ex.Message}");
            }

        }
        [HttpPut]
        public async  Task<IActionResult> Put(int id, Evento model)
        {
             try
            {
                var eventos = await _eventoService.UpdateEvento(id, model);
                if(eventos == null) return BadRequest("Nenhum Eventos por tema não Encontrado!");

                return Ok(eventos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(500, $"Erro ao tentar atualizar esta porra -> {ex.Message}");
            }

        }

        /// <summary>
        /// Deletes a specific Event.
        /// </summary>
        /// <param name="id">Parece óbivio, mas é o Id do Evento mesmo.</param>    
        [HttpDelete]
        public async  Task<IActionResult>  Delete(int id)
        { 
             try
            {
                if(await _eventoService.DeleteEvento(id))
                    return Ok("Deleteado com sucesso");

                return BadRequest("Evento Não Deletado");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(500, $"Erro ao tentar deletar esta porra -> {ex.Message}");
            }

        }



    }
}