using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular",
                Local = "BH",
                Lote = "Primeiro",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString()
            },
            new Evento()
            {
                EventoId = 2,
                Tema = "Ionic",
                Local = "SP",
                Lote = "Primeiro",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(1).ToString()
            }} ;
        public EventoController()
        {

        }
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id){
            return _eventos.Where(evento => evento.EventoId == id);
        }

         
    }
}