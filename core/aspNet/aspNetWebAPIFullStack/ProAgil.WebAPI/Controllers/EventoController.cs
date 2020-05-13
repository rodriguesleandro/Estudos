using System;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebAPI.Model;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController :ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get(){
            return new Evento[]{
                new Evento(){
                    EventoId = 666,
                    Tema = "Cachaça",
                    Local="bar do pinga",
                    Lote="1",
                    QtdPessoas=5,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento(){
                    EventoId = 999,
                    Tema = "Pinga",
                    Local="bar do conhaque",
                    Lote="4",
                    QtdPessoas=100
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id){
            return new Evento[]{
                new Evento(){
                    EventoId = 666,
                    Tema = "Cachaça",
                    Local="bar do pinga",
                    Lote="1",
                    QtdPessoas=5,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento(){
                    EventoId = 999,
                    Tema = "Pinga",
                    Local="bar do conhaque",
                    Lote="4",
                    QtdPessoas=100
                }
            }.FirstOrDefault(e => e.EventoId == id);
        }
        
    }
}