using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class EventoPersist :  IEventoPersist
    {
        public readonly ProEventosContext _contexto;
        public EventoPersist(ProEventosContext context)
        {
            this._contexto = context;
            //this._contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _contexto.Eventos
                .Include(evento => evento.Lotes)
                .Include(evento => evento.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(evento => evento.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(evento => evento.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _contexto.Eventos
                .Include(evento => evento.Lotes)
                .Include(evento => evento.RedesSociais);
                
            if(includePalestrantes){
                query = query
                .Include(evento => evento.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(evento => evento.Id)
                        .Where(evento => evento.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
           IQueryable<Evento> query = _contexto.Eventos
                .Include(evento => evento.Lotes)
                .Include(evento => evento.RedesSociais);
                
            if(includePalestrantes){
                query = query
                .Include(evento => evento.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Palestrante);
            }

            query = query.AsNoTracking().Where(evento => evento.Id == EventoId);
                        

            return await query.FirstOrDefaultAsync();
        }
               
    }
}