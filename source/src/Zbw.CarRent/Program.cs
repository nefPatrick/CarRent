using Zbw.CarRent.General.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Zbw.CarRent.CustomerManagement.Domain;
using Zbw.CarRent.CustomerManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarRentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZbwCarrentContext")));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
