using Microsoft.EntityFrameworkCore;
using SGC.Models;

namespace SGC.db.initialData
{
    public static class CreateStreet
    {
        public static void Execute(ModelBuilder modelBuilder)
        {
            // Красноярск
            var lst = new List<Street> {
                new Street
                {
                        Id = 1,
                        Name = "Батурина Красноярск",
                        LocalityId = 1,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 2,
                        Name = "Взлетная Красноярск",
                        LocalityId = 1,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 3,
                        Name = "60 лет Образования СССР",
                        LocalityId = 1,
                        StreetPrefixId = 2,
                },
                new Street
                {
                        Id = 4,
                        Name = "им. газеты Красноярский Рабочий",
                        LocalityId = 1,
                        StreetPrefixId = 2,
                },
                new Street
                {
                        Id = 5,
                        Name = "им. газеты Красноярский Рабочий",
                        LocalityId = 1,
                        StreetPrefixId = 2,
                },

            };
            modelBuilder.Entity<Street>().HasData(lst);

            //Ачинск
            lst = new List<Street> {
                new Street
                {
                        Id = 6,
                        Name = "Абаканская",
                        LocalityId = 2,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 7,
                        Name = "Верность",
                        LocalityId = 2,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 8,
                        Name = "Гоголевская",
                        LocalityId = 2,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 9,
                        Name = "Гоголевская",
                        LocalityId = 2,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 10,
                        Name = "Гаражный",
                        LocalityId = 3,
                        StreetPrefixId = 1,
                },


            };
            modelBuilder.Entity<Street>().HasData(lst);

            //Лесосибирск
            lst = new List<Street> {
                new Street
                {
                        Id = 11,
                        Name = "Абаканский",
                        LocalityId = 3,
                        StreetPrefixId = 3,
                },
                new Street
                {
                        Id = 12,
                        Name = "Академическая",
                        LocalityId = 3,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 13,
                        Name = "Белая",
                        LocalityId = 3,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 14,
                        Name = "Горького",
                        LocalityId = 3,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 15,
                        Name = "Восстания",
                        LocalityId = 3,
                        StreetPrefixId = 1,
                },



            };
            modelBuilder.Entity<Street>().HasData(lst);

            //Шарыпово
            lst = new List<Street> {
                
                new Street
                {
                        Id = 16,
                        Name = "Байконур",
                        LocalityId = 4,
                        StreetPrefixId = 2,
                },
                new Street
                {
                        Id = 17,
                        Name = "Заводская",
                        LocalityId = 4,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 18,
                        Name = "Индустриальная",
                        LocalityId = 4,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 19,
                        Name = "Короткая",
                        LocalityId = 4,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 20,
                        Name = "Переулок МТМ",
                        LocalityId = 4,
                        StreetPrefixId = 3,
                },



            };
            modelBuilder.Entity<Street>().HasData(lst);

            //Дивногорск
            lst = new List<Street> {
     
                new Street
                {
                        Id = 21,
                        Name = "Балахтинская",
                        LocalityId = 5,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 22,
                        Name = "Дуговая",
                        LocalityId = 5,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 23,
                        Name = "Еловая",
                        LocalityId = 5,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 24,
                        Name = "Добрая",
                        LocalityId = 5,
                        StreetPrefixId = 1,
                },
                  new Street
                {
                        Id = 25,
                        Name = "Школьный",
                        LocalityId = 5,
                        StreetPrefixId = 3,
                },



            };
            modelBuilder.Entity<Street>().HasData(lst);

            //Сосновоборск
            lst = new List<Street> {

                new Street
                {
                        Id = 26,
                        Name = "Большая поляна",
                        LocalityId = 6,
                        StreetPrefixId = 1,
                },
                new Street
                {
                        Id = 27,
                        Name = "Майский",
                        LocalityId = 6,
                        StreetPrefixId = 3,
                },
                new Street
                {
                        Id = 28,
                        Name = "Мирный",
                        LocalityId = 6,
                        StreetPrefixId = 3,
                },
                new Street
                {
                        Id = 29,
                        Name = "Городской",
                        LocalityId = 6,
                        StreetPrefixId = 3,
                }, 
                new Street
                {
                        Id = 30,
                        Name = "Дружный",
                        LocalityId = 6,
                        StreetPrefixId = 3,
                },
                new Street
                {
                        Id = 31,
                        Name = "Заводская",
                        LocalityId = 6,
                        StreetPrefixId = 1,
                },



            };
            modelBuilder.Entity<Street>().HasData(lst);


        }
    }
}
