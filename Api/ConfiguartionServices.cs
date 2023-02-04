using CVGeneratorApp.Api.Common.Dtos.Validators;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CVGeneratorApp.Api
{
    public static class ConfiguartionServices
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers();
            serviceCollection.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            //Connection to Database
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //AddContainerServices
            serviceCollection.AddScoped<IStorageService, StorageService>();
            return serviceCollection;
        }
    }
}
