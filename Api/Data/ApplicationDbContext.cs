using CVGeneratorApp.Api.Core.Entities;
using CVGeneratorApp.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CVGeneratorApp.Api.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Sector> Sectors { get; set; }=null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
    
}
