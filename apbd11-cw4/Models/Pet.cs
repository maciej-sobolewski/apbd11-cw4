namespace apbd11_cw4.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public decimal Weight { get; set; }
        public required string FurColor { get; set; }
    }
}
