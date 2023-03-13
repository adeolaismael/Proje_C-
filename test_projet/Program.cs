using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test_projet.Data;
using test_projet.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<test_projetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("test_projetContext") ?? throw new InvalidOperationException("Connection string 'test_projetContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
