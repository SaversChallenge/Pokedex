using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo;
using Savers.Challenges.Pokedex.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGetPokedexEntries, PokedexRepo>();
builder.Services.AddTransient<IPokedexFilter, PokedexFilterService>();

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
