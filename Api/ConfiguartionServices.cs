using CVGeneratorApp.Api.Common.Dtos.Validators;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.HelperServices.Abstractions;
using CVGeneratorApp.Api.HelperServices.Concrete;
using CVGeneratorApp.Api.Services.Abstactions;
using CVGeneratorApp.Api.Services.Concrete;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Abstractions.Base;
using CVGeneratorApp.Api.StorageServices.Concrete;
using CVGeneratorApp.Api.StorageServices.Concrete.Base;
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
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            //Connection to Database
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddScoped<ApplicationDbContextInitialiser>();
            //AddContainerServices
            serviceCollection.AddScoped<IHelperAccessor, HelperAccessor>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IPersonService, PersonService>();
            return serviceCollection;
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
