using apbd11_cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd11_cw4.Controllers
{
    [ApiController]
    [Route("api/pets/{petId}/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int petId)
        {
            var visits = Database.Appointments.Where(v => v.PetId == petId);
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult Create(int petId, [FromBody] Appointment newAppointment)
        {
            if (!Database.Pets.Any(p => p.Id == petId))
                return NotFound("Animal not found");

            newAppointment.Id = Database.Appointments.Any() ? Database.Appointments.Max(a => a.Id) + 1 : 1;
            newAppointment.PetId = petId;
            Database.Appointments.Add(newAppointment);
            return CreatedAtAction(null, new { petId, id = newAppointment.Id }, newAppointment);
        }
    }
}
