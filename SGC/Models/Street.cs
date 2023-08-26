using Microsoft.IdentityModel.Tokens;

namespace SGC.Models
{
    public class Street
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocalityId { get; set; }
        public Locality Locality { get; set; } = null!;

        public int StreetPrefixId { get; set; }
        public StreetPrefix? StreetPrefix { get; set; }
        public ICollection<Home> Homes { get; } = new List<Home>();

        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return this.Name.IsNullOrEmpty();
            return this.Name.Equals(obj);
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
