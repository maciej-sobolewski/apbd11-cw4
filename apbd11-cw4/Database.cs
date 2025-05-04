using apbd11_cw4.Models;

namespace apbd11_cw4
{
    public class Database
    {
        public static List<Pet> Pets { get; } = new()
        {
            new Pet() { Id = 1, Category = "Dog", FurColor = "Brown", Name = "Fafik", Weight = 20.1m },
            new Pet() { Id = 2, Category = "Cat", FurColor = "Orange", Name = "Kicia", Weight = 5.6m },
            new Pet() { Id = 3, Category = "Horse", FurColor = "Black", Name = "Rafal", Weight = 420.5m }
        };

        public static List<Appointment> Appointments { get; } = new();
    }
}
