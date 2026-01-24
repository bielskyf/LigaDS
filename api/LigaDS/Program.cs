using LigaDS.Services;
using LigaDS.Services.Interfaces;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var envFile = Path.Combine(Directory.GetCurrentDirectory(), ".env.local");
if (File.Exists(envFile))
{
    DotNetEnv.Env.Load(envFile);
}

builder.Services.AddScoped<IApiFootballService, ApiFootballService>();
builder.Services.AddScoped<IAtletaService, AtletaService>();
builder.Services.AddScoped<IEquipeService, EquipeService>();

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
