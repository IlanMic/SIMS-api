using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Sims.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at /*https://aka.ms/aspnetcore/swashbuckle*/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SimsContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("SimsDB"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
    });

//REAL LOGGING DONE IN CONTROLLERS, piping together what we want to log.
builder.Services.AddHttpLogging(options =>
{
    //options.LoggingFields = HttpLoggingFields.All; //Dangerous, will log bodies;
    options.LoggingFields = HttpLoggingFields.RequestPath |      // Ex: /api/dataformats
                            HttpLoggingFields.RequestProtocol |  // Ex: HTTP/2
                            HttpLoggingFields.RequestMethod |    // Ex: GET
                            HttpLoggingFields.ResponseStatusCode | // Ex: 200                                                            
                            HttpLoggingFields.ResponsePropertiesAndHeaders; // Ex Content-Type: application/json; charset=utf-8 Date: Tue, 11 Oct 2022 12:19:26 GMT
                                                                            
});

var app = builder.Build();

//THIS IS JUST FOR DEBUGGING
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
