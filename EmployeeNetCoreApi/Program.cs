using EmployeeNetCoreApi.Data;
using EmployeeNetCoreApi.Repository;

var builder = WebApplication.CreateBuilder(args);
// Configuration
builder.Services.AddDbContext<EmployeeDbContext>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// Add services to the container.

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
