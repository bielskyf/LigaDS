using LigaDS.Data;
using LigaDS.Services;
using LigaDS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var envFile = Path.Combine(Directory.GetCurrentDirectory(), ".env.local");
if (File.Exists(envFile))
{
    DotNetEnv.Env.Load(envFile);
}

builder.Services.AddDbContext<LigaDbContext>( options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddHttpClient<IApiFootballService, ApiFootballService>( client =>
{
    var apiKey = Environment.GetEnvironmentVariable("API_FOOTBALL_KEY");

    if (string.IsNullOrEmpty(apiKey))
    {
        throw new Exception("API_FOOTBALL_KEY não configurada no .env.local");
    }

    client.BaseAddress = new Uri("https://v3.football.api-sports.io/");
    client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddScoped<IAtletaFetchService, AtletaFetchService>();
builder.Services.AddScoped<IEquipeFetchService, EquipeFetchService>();
builder.Services.AddScoped<ILigaFetchService, LigaFetchService>();

builder.Services.AddControllers();
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
