using Microsoft.EntityFrameworkCore;
using SGC.Models;

namespace SGC.db.initialData
{
    public static class CreateLocalityPrefix
    {
        public static void Execute(ModelBuilder modelBuilder)
        {
            var lst = new List<LocalityPrefix> {
                new LocalityPrefix
                {
                        Id = 1,
                        Name = "Город",
                        ShortName = "г.",
                },
                new LocalityPrefix
                {
                        Id = 2,
                        Name = "Деревня",
                        ShortName = "д.",
                },
                new LocalityPrefix
                {
                        Id = 3,
                        Name = "Поселок",
                        ShortName = "п.",
                },
                 new LocalityPrefix
                {
                        Id = 4,
                        Name = "Поселок городского типа",
                        ShortName = "пгт.",
                },
            };
            modelBuilder.Entity<LocalityPrefix>().HasData(lst);


        }
    }
}
