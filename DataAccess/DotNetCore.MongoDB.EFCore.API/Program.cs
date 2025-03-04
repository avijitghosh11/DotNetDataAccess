using DotNetCore.MongoDB.EFCore.API.Data;
using DotNetCore.MongoDB.EFCore.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

string dataBase = builder.Configuration.GetValue<string>("AppDatabaseSettings:DatabaseName");
string conn = builder.Configuration.GetValue<string>("AppDatabaseSettings:ConnectionString");
var mongoClient = new MongoClient(conn);
builder.Services.AddMongoDB<MongoContext>(mongoClient, dataBase);

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

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
