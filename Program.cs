using Microsoft.EntityFrameworkCore;
using TestLicorera.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LicoreraDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("stringLicoreraDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.WithOrigins("http://localhost:5174");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
