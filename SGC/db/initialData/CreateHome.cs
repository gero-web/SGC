using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using SGC.Models;

namespace SGC.db.initialData
{
    public static class CreateHome
    {
        private static readonly Random rnd = new Random();
        private static IList<Home> RandomData(int offsetStreet, int offsetHome,int countStreet, int countHome = 10)
        {
            
            var lst = new List<Home>();  

            for (int i = 1; i <= countStreet; i++)
            {
                for (int j = 1; j <= countHome; j++)
                {
                    lst.Add(new Home
                    {
                        Id = offsetHome + j,
                        Name = $"Дом №{rnd.Next(1, 100).ToString()}",
                        CountApartments = rnd.Next(1, 50),
                        StreetId = offsetStreet + i,

                    });
                }
               
                offsetHome += countHome;
            }
           
            
            return lst;
        }

       

        public static void Execute(ModelBuilder modelBuilder)
        {

            // Красноярск
            var lst = RandomData(0, 0, 5);


            //Ачинск
            lst.AddRange(RandomData(5, 50, 5));
           

            //Лесосибирск
            lst.AddRange(RandomData(10, 100, 5));
            

            //Шарыпово
            lst.AddRange(RandomData(15, 150, 5));
           

            //Дивногорск
            lst.AddRange(RandomData(20, 200, 5));
           

            //Сосновоборск
            lst.AddRange(RandomData(25, 250, 6));
            modelBuilder.Entity<Home>().HasData(lst);


            CreateApartments.Execute(lst, modelBuilder);

        }
    }
}
