using Microsoft.EntityFrameworkCore;
using SGC.Models;

namespace SGC.db.initialData
{
    public static class CreateLocality 
    {
        public static void Execute(ModelBuilder modelBuilder)
        {
            var lst = new List<Locality> {
                new Locality
                {
                        Id = 1,
                        Name = "Красноярск",
                        LocalityPrefixId = 1,

                },
                new Locality
                {
                        Id = 2,
                        Name = "Ачинск",
                        LocalityPrefixId = 1,

                },
                new Locality
                {
                        Id = 3,
                        Name = "Лесосибирск,",
                        LocalityPrefixId = 1,

                },
                new Locality
                {
                        Id = 4,
                        Name = "Шарыпово",
                        LocalityPrefixId = 1,

                },
                new Locality
                {
                        Id = 5,
                        Name = "Дивногорск",
                        LocalityPrefixId = 1,

                },
                 new Locality
                {
                        Id = 6,
                        Name = "Сосновоборск",
                        LocalityPrefixId = 1,

                },
            };
            modelBuilder.Entity<Locality>().HasData(lst);


        }
    }
}
