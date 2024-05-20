using MediatR;
using Microsoft.EntityFrameworkCore;
using Space_Rover.Core.Command.Rover;
using Space_Rover.Core.InterFaces;
using Space_Rover.Infrastructr;
using Space_Rover.Infrastructr.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<IRoverRepository, RoverRepository>();
builder.Services.AddScoped<Space_Rover.Core.InterFaces.IMomentManager, Space_Rover.Core.Entity.MomentManager>();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(CreateRoverCommand));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(builder.Configuration.GetValue<string>("DefaultConnection")));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
}



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