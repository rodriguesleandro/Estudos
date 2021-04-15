using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        public readonly ProEventosContext _contexto;
        public PalestrantePersist(ProEventosContext context)
        {
            this._contexto = context;

        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _contexto.Palestrantes
                .Include(palestrante => palestrante.RedeSociais);
                
            if(includeEventos){
                query = query
                .Include(palestrante => palestrante.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Evento);
            }

            query = query.AsNoTracking().OrderBy(palestrante => palestrante.Id);
                        

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes
                .Include(palestrante => palestrante.RedeSociais);
                
            if(includeEventos){
                query = query
                .Include(palestrante => palestrante.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Evento);
            }

            query = query.AsNoTracking().OrderBy(palestrante => palestrante.Id)
                        .Where(palestrante => palestrante.Nome.ToLower().Contains(nome.ToLower()));
                        

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes
                .Include(palestrante => palestrante.RedeSociais);
                
            if(includeEventos){
                query = query
                .Include(palestrante => palestrante.PalestrantesEventos)
                .ThenInclude(palestranteEvento => palestranteEvento.Evento);
            }

            query = query.AsNoTracking().Where(palestrante => palestrante.Id == PalestranteId);
                        

            return await query.FirstOrDefaultAsync();
        }        
    }
}