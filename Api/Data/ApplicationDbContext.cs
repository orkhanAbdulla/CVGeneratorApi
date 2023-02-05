using CVGeneratorApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CVGeneratorApp.Api.Data
{
    public class ApplicationDbContext :  DbContext
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
