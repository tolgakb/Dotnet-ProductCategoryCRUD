using Microsoft.EntityFrameworkCore;
using ProductCategoryManagement.Persistence.DbContexts;
using ProductCategoryManagement.Application;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Persistence.Repositories;
using ProductCategoryManagement.WebApi.Extensions;
using Serilog;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using FluentValidation;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory;

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // add this
    .CreateLogger();

Log.Information("Starting web application");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(); // <-- Add this line


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();



var app = builder.Build();

app.ConfigureExceptionHandler();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
   options.WithOrigins("http://localhost:4200")
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
