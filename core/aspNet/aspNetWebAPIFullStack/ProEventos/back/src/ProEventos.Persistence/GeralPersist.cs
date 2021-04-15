using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        public readonly ProEventosContext _contexto;
        public GeralPersist(ProEventosContext context)
        {
            this._contexto = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            _contexto.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }

                
    }
}