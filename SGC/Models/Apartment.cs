using Microsoft.IdentityModel.Tokens;

namespace SGC.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FIOOnwer { get; set; }

        public int HomeId { get; set; }

        public Home? Home { get; set; } = null!;

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
