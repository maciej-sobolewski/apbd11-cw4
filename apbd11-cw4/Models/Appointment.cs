namespace apbd11_cw4.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public required string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
