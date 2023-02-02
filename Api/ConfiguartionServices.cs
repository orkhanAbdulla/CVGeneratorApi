using CVGeneratorApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CVGeneratorApp.Api
{
    public static class ConfiguartionServices
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers();
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            //Connection to Database
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return serviceCollection;
        }
    }
}
