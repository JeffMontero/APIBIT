using BusinessLogic.Service;
using DataAccess.Data;
using ApiBit.Interface;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region : Instancias de dependencias, registro de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDB")));
builder.Services.AddTransient<ICliente, ClienteService>();
builder.Services.AddTransient<IServicio, ServicioService>();
#endregion : Instancias de dependencias, registro de servicios

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
