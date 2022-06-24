using Microsoft.EntityFrameworkCore;
using Netflix_Catalog_API;
using Netflix_Catalog_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilmsContext>(p => p.UseInMemoryDatabase("FilmsDB"));
builder.Services.AddSqlServer<FilmsContext>("Data Source= DESKTOP-VRL3HD3\\SQLEXPRESS2;Initial Catalog=FilmsDb;user id=sa;password=pass");

builder.Services.AddScoped<IGenresServices, GenresServices>();
builder.Services.AddScoped<IFilmsServices, FilmsServices>();

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
