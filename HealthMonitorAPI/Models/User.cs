using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorAPI.Models
{
    public class User
    {
        // One to many relationships between user and appointments.
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string UserRoles { get; set; }
        [Required]
        public string UserEmail { get; set; }

    }
}
