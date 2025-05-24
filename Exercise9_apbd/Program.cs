using Exercise9_apbd.DAL;
using Exercise9_apbd.Models;
using Exercise9_apbd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddDbContext<ex9DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPservice, Pservice>();



builder.Services.AddOpenApi();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
