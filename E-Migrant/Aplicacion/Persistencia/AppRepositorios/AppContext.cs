using Microsoft.EntityFrameworkCore;
using Dominio;


namespace Persistencia{
    public class AppContext:DbContext
    {
        //Atributos

        public DbSet<Migrante> Migrantes{get;set;}
        public DbSet<Oferta> Ofertas{get;set;}        
        public DbSet<Colaboradora> Colaboradoras{get;set;}
        public DbSet<Solicitud> Solicitudes{get;set;}
        public DbSet<Evaluacion> Evaluaciones{get;set;}
        public DbSet<Novedad> Novedades{get;set;}
             
        
        //Metodos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=HackatonGrupo36WebDevelopers");
            }
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=> new{x.EquipoId,x.TorneoId});
        }
*/

    }

}