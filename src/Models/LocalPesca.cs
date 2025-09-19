namespace Versão_SegundoSemestre.Models
{
    public class LocaisPesca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<string> FishTypes { get; set; } = new List<string>();
        public string City { get; set; }
        public double Rating { get; set; }
        public List<string> Facilities { get; set; } = new List<string>();
        public string BestSeason { get; set; }
    }
}
