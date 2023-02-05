using CVGeneratorApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;

        public ApplicationDbContextInitialiser(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
            // Default data Sector
            // Seed, if necessary
            if (!_context.Sectors.Any())
            {
                await _context.Sectors.AddRangeAsync(new List<Sector> 
                {
                    new Sector(){ Name="Digital Marketing"},
                    new Sector(){ Name="Programlaşdırma"},
                    new Sector(){ Name="Dizayn"},
                    new Sector(){ Name="IT və Kiber Təhllükəsizlik"}
                }
                );
                   await _context.SaveChangesAsync();
            }
        }

    }
}
