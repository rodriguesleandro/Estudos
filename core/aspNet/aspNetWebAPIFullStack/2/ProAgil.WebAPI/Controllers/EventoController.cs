using System;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebAPI.Model;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using ProAgil.WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public DataContext _context { get; }
        public EventoController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Informação Inexistente");
            }
            // return new Evento[]{
            //     new Evento(){
            //         EventoId = 666,
            //         Tema = "Cachaça",
            //         Local="bar do pinga",
            //         Lote="1",
            //         QtdPessoas=5,
            //         DataEvento = DateTime.Now.AddDays(2).ToString()
            //     },
            //     new Evento(){
            //         EventoId = 999,
            //         Tema = "Pinga",
            //         Local="bar do conhaque",
            //         Lote="4",
            //         QtdPessoas=100
            //     }
            // };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(ev => ev.EventoId == id);
                return Ok(result);    
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Informação Inexistente");                
            }
            // return new Evento[]{
            //     new Evento(){
            //         EventoId = 666,
            //         Tema = "Cachaça",
            //         Local="bar do pinga",
            //         Lote="1",
            //         QtdPessoas=5,
            //         DataEvento = DateTime.Now.AddDays(2).ToString()
            //     },
            //     new Evento(){
            //         EventoId = 999,
            //         Tema = "Pinga",
            //         Local="bar do conhaque",
            //         Lote="4",
            //         QtdPessoas=100
            //     }
            // }.FirstOrDefault(e => e.EventoId == id);
        }

    }
}