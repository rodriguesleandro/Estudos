using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext :DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedeSocials { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public ProEventosContext(DbContextOptions<ProEventosContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
            .HasMany(evento => evento.RedesSociais)
            .WithOne(redeSocial => redeSocial.Evento)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
            .HasMany(palestrante => palestrante.RedeSociais)
            .WithOne(redeSocial => redeSocial.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}