using Microsoft.EntityFrameworkCore;
using SGC.Models;

namespace SGC.db.initialData
{
    public  static class CreateApartments
    {
        public static void Execute( IList<Home> lst, ModelBuilder modelBuilder)
        {
            Random rnd = new Random();
            var lstApartaments = new List<Apartment>();
            int offsetApartaments = 0;
            foreach (var item in lst)
            {
                int idHome = item.Id;
                int CountApartments = item.CountApartments;

                for (int i = 1; i <= CountApartments; i++)
                {
                    lstApartaments.Add(new Apartment
                    {
                        HomeId = idHome,
                        FIOOnwer = "",
                        Id = i + offsetApartaments,
                        Name = $"Квартира №{rnd.Next(1, 100).ToString()}",
                    });
                }
                offsetApartaments += CountApartments;
            }
            modelBuilder.Entity<Apartment>().HasData(lstApartaments);

        }
    }
}
