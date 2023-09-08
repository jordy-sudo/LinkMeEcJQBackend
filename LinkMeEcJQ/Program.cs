using LinkMeEcJQ.Infrastructure;
using LinkMeEcJQ;
using MediatR;
using LinkMeEcJQ.Domain;
using LinkMeEcJQ.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ProductRepository>();


builder.Services.AddScoped<IMongoDB>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("MongoDb"); 
    var databaseName = config.GetValue<string>("MongoDbDatabaseName");
    return new ApplicationDbContext(connectionString, databaseName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin(); 
    options.AllowAnyHeader(); 
    options.AllowAnyMethod(); 
});


app.MapControllers();


app.Run();


