using API.Extension;
using AspNetCoreRateLimit;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureRateLimitiong();
builder.Services.AddJwt(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddDbContext<ParkingContext>(options =>
{
    var serverVErsion = new MySqlServerVersion(new Version(8, 0, 29));
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVErsion);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<ParkingContext>();
        await context.Database.MigrateAsync();
        await ParkingContextSeed.SeedAsync(context,loggerFactory);
        await ParkingContextSeed.SeedRolesAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<ParkingContext>();
        logger.LogError(ex,"Erro en la Migración");
        
    }
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
