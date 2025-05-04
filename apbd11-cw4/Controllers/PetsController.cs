using apbd11_cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd11_cw4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(Database.Pets);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pet = Database.Pets.FirstOrDefault(p => p.Id == id);
            return pet is not null ? Ok(pet) : NotFound();
        }

        [HttpGet("getByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var result = Database.Pets.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet newPet)
        {
            newPet.Id = Database.Pets.Any() ? Database.Pets.Max(p => p.Id) + 1 : 1;
            Database.Pets.Add(newPet);
            return CreatedAtAction(nameof(GetById), new { id = newPet.Id }, newPet);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pet updated)
        {
            var pet = Database.Pets.FirstOrDefault(p => p.Id == id);
            if (pet is null) return NotFound();
            pet.Name = updated.Name;
            pet.Category = updated.Category;
            pet.Weight = updated.Weight;
            pet.FurColor = updated.FurColor;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = Database.Pets.FirstOrDefault(p => p.Id == id);
            if (pet is null) return NotFound();
            Database.Pets.Remove(pet);
            Database.Appointments.RemoveAll(a => a.PetId == id);
            return NoContent();
        }
    }
}
