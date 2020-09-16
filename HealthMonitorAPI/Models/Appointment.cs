using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorAPI.Models
{
    public class Appointment       
    { 

        // One user can have many appointments.
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }
        [Required]

        public string AppointmentType { get; set; }
        [Required]
        public string AppointmentDesc { get; set; }
        [Required]
        public string AppointmentText { get; set; }
        [Required]
        public string DoctorsName { get; set; }
        // FK
        [Required]
        public int UserID { get; set; }
        [Required]
        public string CreatedBy { get; set; }


    }
}
