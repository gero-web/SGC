using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SGC.db.initialData;
using SGC.Models;

namespace SGC.db
{
    public class EFContext : DbContext
    {
        public DbSet<Locality> Locality { get; set; }
        public DbSet<LocalityPrefix> LocalityPrefix { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<StreetPrefix> StreetPrefixes { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Apartment> Apartments { get; set; }


        public EFContext(DbContextOptions<EFContext> options) : base(options){
        
            Database.EnsureCreated();
        }

       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            CreateLocalityPrefix.Execute(modelBuilder);
            CreateLocality.Execute(modelBuilder);
            CreateStreetPrefix.Execute(modelBuilder);
            CreateStreet.Execute(modelBuilder);
            CreateHome.Execute(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
