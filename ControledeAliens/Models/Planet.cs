namespace ControledeAliens.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long Population { get; set; } = 0;
    }
}
