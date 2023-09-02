namespace ControledeAliens.Models
{
    public class AlienPower
    {
        public int AlienId { get; set; }
        public Alien Alien { get; set; }

        public int PowerId { get; set; }
        public Power Power { get; set; }
    }
}
