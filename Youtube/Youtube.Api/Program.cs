using Microsoft.EntityFrameworkCore;
using Youtube.Domain;
using Youtube.Infrastructure;
using Youtube.Infrastructure.Repositories;
using Youtube.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<YoutubeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YoutubeApi"));

});


builder.Services.AddTransient<YoutubeDbContext>();
builder.Services.AddTransient<IBaseRepository<Videos>, VideosRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// APÝ ' YÝ PAYLAÞIMA AÇMA
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
