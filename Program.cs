using BackendStageTwo.DataAccess.Context;
using BackendStageTwo.DataAccess.Interface;
using BackendStageTwo.DataAccess.Repository;
using BackendStageTwo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   


var connection = builder
        .Configuration.
        GetConnectionString("User");
builder.Services.AddDbContext<UserContext>( options => options.UseSqlServer(connection));

builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.Services.GetRequiredService<UserContext>().Database.EnsureCreatedAsync().Wait();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
