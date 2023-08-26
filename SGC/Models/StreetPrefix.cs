namespace SGC.Models
{
    public class StreetPrefix
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

        public ICollection<Street> Street { get; set; } = new List<Street>();
    }
}
