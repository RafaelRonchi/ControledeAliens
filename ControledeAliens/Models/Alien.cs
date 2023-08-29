namespace ControledeAliens.Models
{
    public class Alien
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specie { get; set; } = string.Empty;
        public double Height { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Body { get; set; } = string.Empty;


        public int PowerId { get; set; }
        public int PlanetId { get; set; }
        public Power Power { get; set; }
        public Planet Planet { get; set; }
    }
}
