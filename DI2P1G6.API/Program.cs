using DI2P1G6.Booking.Repository;
using DI2P1G6.Booking.Repository.Contract;
using DI2P1G6.Booking.Service;
using DI2P1G6.Booking.Service.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Injection du dépôt et service avec la chaîne de connexion
builder.Services.AddScoped<IRessourcesRepository>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("BookingConnectionstring");
    return new RessourcesRepository(connectionString);
});

builder.Services.AddScoped<IRessourcesService, RessourcesService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
