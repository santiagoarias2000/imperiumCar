using imperiumCar2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace imperiunCar2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarBrands> CarBrands { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Transfers> Transfers { get; set; }
        public DbSet<TypesPersons> TypesPersons  { get; set; }
        public DbSet<Vehicles> Vehicle { get; set; }
    }
}