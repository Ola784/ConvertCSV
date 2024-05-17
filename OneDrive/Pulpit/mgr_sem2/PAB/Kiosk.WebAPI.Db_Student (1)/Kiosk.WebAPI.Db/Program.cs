using Microsoft.EntityFrameworkCore;
using Kiosk.WebAPI.Persistance;
using Kiosk.WebAPI.Db.Services;
using FluentValidation;
using Kiosk.WebAPI.Dto;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// rejestracja walidatora
builder.Services.AddScoped<IValidator<CreateProductDto>, RegisterCreateProductDtoValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// rejestracja kontekstu bazy w kontenerze IoC
var sqliteConnectionString = "Data Source=Kiosk.WebAPI.db";
builder.Services.AddDbContext<KioskDbContext>(options =>
    options.UseSqlite(sqliteConnectionString));
builder.Services.AddScoped<IKioskUnitOfWork, KioskUnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<DataSeeder>();
// Rejestracja automatycznej walidacji
// FluentValidation waliduje i przekazuje wynik przez ModelState
builder.Services.AddFluentValidationAutoValidation();


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

// seeding data
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}

app.Run();
