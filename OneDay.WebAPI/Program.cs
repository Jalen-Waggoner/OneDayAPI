using System.Text;
using OneDay.Services.Jalen;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneDay.Data;
using OneDay.Services;

using OneDay.Services.Post;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add connection string here
//Add Floria Service/Interface for Dependency Injection here
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IJalenService, JalenService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IFloriaService, FloriaService>();

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
