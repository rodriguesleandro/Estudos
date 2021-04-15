using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersit;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersit, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersit = geralPersit;

        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersit.Add<Evento>(model);
                if(await _geralPersit.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                    
                }
                return null;
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId);
                if(evento == null) return null;

                model.Id = evento.Id;

                _geralPersit.Update<Evento>(model);

                if(await _geralPersit.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                    
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
                
                if(evento == null) throw new Exception("Evento Não Encontrado");
                 

                _geralPersit.Delete<Evento>(evento);

            return await _geralPersit.SaveChangesAsync();
                

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosAsync(includePalestrantes);   
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        
    }
}