using CVGeneratorApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Sector> Sectors { get; set; }=null!;

    }
}
