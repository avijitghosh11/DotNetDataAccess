using DotNetCore.MongoDB.API.DatabaseCore;
using DotNetCore.MongoDB.API.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<AppDatabaseSettings>(builder.Configuration.GetSection(nameof(AppDatabaseSettings)));
builder.Services.AddSingleton<IAppDatabaseSettings>(db => 
    db.GetRequiredService<IOptions<AppDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(cl => 
    new MongoClient(builder.Configuration.GetValue<string>("AppDatabaseSettings:ConnectionString"))
    );
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

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
