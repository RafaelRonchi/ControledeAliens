namespace ControledeAliens.Models
{
    public class Alien
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public double Height { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Body { get; set; } = string.Empty;


        public int PlanetId { get; set; }
        public ICollection<AlienPower> AlienPowers { get; set; } = new List<AlienPower>();

        public Planet Planet { get; set; }
    }
}
