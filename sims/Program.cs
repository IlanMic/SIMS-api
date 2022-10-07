using Microsoft.EntityFrameworkCore;
using Sims.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SimsContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("SimsDB"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
    });

var app = builder.Build();

//Logging calls to the API, so called "Middleware"
app.UseHttpLogging();
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
