using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Sims.Data;

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

// Filtering for logger, piping together what we want to log. 
builder.Services.AddHttpLogging(options =>
{
    //options.LoggingFields = HttpLoggingFields.All; //Dangerous, will log bodies;
    options.LoggingFields = HttpLoggingFields.RequestPath |      // Ex: /api/dataformats
                            HttpLoggingFields.RequestProtocol |  // Ex: HTTP/2
                            HttpLoggingFields.RequestMethod |    // Ex: GET
                            HttpLoggingFields.ResponseStatusCode;// Ex: 200
});

var app = builder.Build();

//Logging calls to the API, so called "Middleware" (Might just end up logging to console and inpractial 
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
