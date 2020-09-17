using HealthMonitorAPI.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorAPI.Models
{
    public class AppDatabase: IdentityDbContext<ApplicationUser>
    {        // Defining each table in the database.

        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Appointment> Appointment { get; set; }


    }
}
