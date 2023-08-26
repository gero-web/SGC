using Microsoft.EntityFrameworkCore;
using SGC.Models;

namespace SGC.db.initialData
{
    public static class CreateStreetPrefix
    {
        public static void Execute(ModelBuilder modelBuilder)
        {
            var lst = new List<StreetPrefix> {
                new StreetPrefix
                {
                        Id = 1,
                        Name = "Улица",
                        ShortName = "ул.",
                },
                new StreetPrefix
                {
                        Id = 2,
                        Name = "Проспект",
                        ShortName = "пр-кт.",
                },
                new StreetPrefix
                {
                        Id = 3,
                        Name = "Переулок",
                        ShortName = "пер.",
                },
                new StreetPrefix
                {
                        Id = 4,
                        Name = "Микрорайон",
                        ShortName = "мкр.",
                },
            };
            modelBuilder.Entity<StreetPrefix>().HasData(lst);


        }
    }
}
