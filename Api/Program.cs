using CVGeneratorApp.Api;
using CVGeneratorApp.Api.Data;
using CVGeneratorApp.Api.StorageServices.Concrete;

var builder = WebApplication.CreateBuilder(args);
// Project Service Configuration

builder.Services.AddStorage<LocalStorage>();
builder.Services.AddConfigurationServices(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
