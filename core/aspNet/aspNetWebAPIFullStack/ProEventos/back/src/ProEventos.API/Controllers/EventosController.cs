using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

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
        public readonly DataContext _contexto;
        public EventosController(DataContext context)
        {
            this._contexto = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _contexto.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _contexto.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }


    }
}