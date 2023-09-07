using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrjtA.Models;

namespace PrjtA
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Coiffeur> Coiffeurs { get; set; }

        public DbSet<Payement> Payments { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Sliders> Sliders { get; set; }

        //Insertting Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}