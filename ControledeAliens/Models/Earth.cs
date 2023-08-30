namespace ControledeAliens.Models
{
    public class Earth
    {
        public int Id { get; set; }
        public int AlienId { get; set; }
        public Alien Alien { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.Now;
        public DateTime ExitTime { get; set; } = new DateTime(1, 1, 1, 0, 0, 0);
    }
}
