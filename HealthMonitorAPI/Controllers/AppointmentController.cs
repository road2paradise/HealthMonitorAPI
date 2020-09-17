using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitorAPI.Authentication;
using HealthMonitorAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthMonitorAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private AppDatabase _context;
        
        // create the context

        public AppointmentController(AppDatabase context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }
        // Create function
        // Adding address based off his/her studentId.
        [HttpPost("{userName}")]
        public async Task<ActionResult<Appointment>> PostStudentAddress(Appointment appointment, string userName)
        {

            // Creates a new entry into the Address table. 
            // The student needs to be found in the Student context and then a new address is
            // inserted into the table. This is necessary as if we do not insert a new student 
            // it will automatically create one (based off the student schema).

            var user =  await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }
            Appointment newAppointment = new Appointment
            {
                AppointmentType = appointment.AppointmentType,
                AppointmentDesc = appointment.AppointmentDesc,
                AppointmentText = appointment.AppointmentText,
                DoctorsName = appointment.DoctorsName,

                ApplicationUser = user,
            };
            _context.Appointment.Add(newAppointment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = newAppointment.AppointmentID }, newAppointment);


        }


        // READ function
        [HttpGet("{userName}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetUserAppointments(string userName)
        {
            return await _context.Appointment.Where(c => c.ApplicationUser.UserName == userName).ToListAsync();
        }
        // READ function
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            return await _context.Appointment.Include(c => c.ApplicationUser).ToListAsync();
        }

        // Update function
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // Delete function
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.AppointmentID == id);
        }



    }
}
