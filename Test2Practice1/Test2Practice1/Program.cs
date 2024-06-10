using Microsoft.EntityFrameworkCore;
using Test2Practice1.Api.MiddleWares;
using Test2Practice1.Api.Repositories;
using Test2Practice1.Api.Services;
using Test2Practice1.DataBase.Context;
using Test2Practice1.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseCOntext>(options =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();

// Adding repositories
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IBoatStandardRepository, BoatStandardRepository>();
builder.Services.AddScoped<ISailboatRepository, SailbhoatRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Adding services
builder.Services.AddScoped<IReservationService, ReservationService>();

// Adding Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();