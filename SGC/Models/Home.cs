using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace SGC.Models
{
    public class Home
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int StreetId { get; set; }
         

        public virtual Street? Street { get; set; }

        [IntegerValidator(MinValue =1 , MaxValue = 100)]
        public int CountApartments { get; set; }   

        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return this.Name.IsNullOrEmpty();

            return this.Name.Equals(obj) ;
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

    }
}
