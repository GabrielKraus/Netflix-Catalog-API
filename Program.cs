using Microsoft.EntityFrameworkCore;
using Netflix_Catalog_API;
using Netflix_Catalog_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<FilmsContext>(p => p.UseInMemoryDatabase("FilmsDB"));
builder.Services.AddSqlServer<FilmsContext>("Data Source=FilmsDb-GabrielKraus.mssql.somee.com;Initial Catalog=FilmsDb-GabrielKraus;user id=GabrielKraus_SQLLogin_1;password=nzya6rmvul");

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
