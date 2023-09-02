namespace ControledeAliens.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<AlienPower> AlienPowers { get; set; } = new List<AlienPower>();

    }
}
