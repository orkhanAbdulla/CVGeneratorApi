using CVGeneratorApp.Api.Core.Entities;
using CVGeneratorApp.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationDbContextInitialiser(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
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
            // Default Roles
            var administratorRole = new IdentityRole("administrator");
            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
            }
            // Default Users

            var administrator = new ApplicationUser { UserName = "Shiraslan", Email = "administrator@localhost.com"};
            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "952103Shir");
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
            // Default data Sector
            // Seed, if necessary
            if (!_context.Sectors.Any())
            {
                await _context.Sectors.AddRangeAsync(new List<Sector> 
                {
                    new Sector(){ Name="Advanced UX / UI"},
                    new Sector(){ Name="Cyber Security"},
                    new Sector(){ Name="Data Science"},
                    new Sector(){ Name="Advanced Back-End Development (Java)"},
                    new Sector(){ Name="Advanced Back-End Development (.Net)"},
                    new Sector(){ Name="Advanced Front-End"},
                    new Sector(){ Name="Mobil App Development"}
                }
                );
                   await _context.SaveChangesAsync();
            }
        }

    }
}
