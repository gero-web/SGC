using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGC.Models
{
    public class LocalityPrefix
    {
        
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

        public ICollection<Locality> Localities { get; set; } = new List<Locality>();
    }
}
