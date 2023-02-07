using CVGeneratorApp.Api.Common.Dtos.Validators;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.Entities;
using CVGeneratorApp.Api.Filters;
using CVGeneratorApp.Api.HelperServices.Abstractions;
using CVGeneratorApp.Api.HelperServices.Concrete;
using CVGeneratorApp.Api.IdentityServices.Abstractions;
using CVGeneratorApp.Api.IdentityServices.Concrete;
using CVGeneratorApp.Api.Services.Abstactions;
using CVGeneratorApp.Api.Services.Concrete;
using CVGeneratorApp.Api.StorageServices.Abstractions;
using CVGeneratorApp.Api.StorageServices.Abstractions.Base;
using CVGeneratorApp.Api.StorageServices.Concrete;
using CVGeneratorApp.Api.StorageServices.Concrete.Base;
using CVGeneratorApp.Api.TokenServices.Abstarctions;
using CVGeneratorApp.Api.TokenServices.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace CVGeneratorApp.Api
{
    public static class ConfiguartionServices
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
            serviceCollection.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            //Connection to Database
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddScoped<ApplicationDbContextInitialiser>();
            //AddIdentityLibrary
            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //AddContainerServices
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<IHelperAccessor, HelperAccessor>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IPersonService, PersonService>();
            serviceCollection.AddScoped<ISectorService, SectorService>();

            // JWT Token Configuration
            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidAudience = configuration["Token:Audience"],
                        ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                        NameClaimType = ClaimTypes.UserData,

                    };

                });

            return serviceCollection;
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
