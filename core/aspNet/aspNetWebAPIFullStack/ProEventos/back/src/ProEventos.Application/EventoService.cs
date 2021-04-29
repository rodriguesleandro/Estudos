using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Application.Dtos;
using AutoMapper;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersit;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;
        public EventoService(IGeralPersist geralPersit, IEventoPersist eventoPersist, IMapper mapper)
        {
            _mapper = mapper;
            _eventoPersist = eventoPersist;
            _geralPersit = geralPersit;

        }
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _geralPersit.Add<Evento>(evento);
                if (await _geralPersit.SaveChangesAsync())
                {
                    var retorno =  await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);
                if (evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _geralPersit.Update<Evento>(evento);

                if (await _geralPersit.SaveChangesAsync())
                {
                    var retorno =  await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);

                if (evento == null) throw new Exception("Evento Não Encontrado");


                _geralPersit.Delete<Evento>(evento);

                return await _geralPersit.SaveChangesAsync();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos =  await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos =  await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<EventoDto> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento =  await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);

                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}