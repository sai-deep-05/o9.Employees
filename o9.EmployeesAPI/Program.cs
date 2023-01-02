using MongoDB.Driver;
using o9.EmployeesAPI.Models;
using o9.EmployeesAPI.Repository;
using o9.EmployeesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

//builder.Services.Configure<MongoDBSettings>(
	//builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoDatabase>(options => {
	var mongosettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>(); //use configuration
	var client = new MongoClient(mongosettings.ConnectionString);
	return client.GetDatabase(mongosettings.DatabaseName);
});

builder.Services.AddSingleton<IEmployeesRepository, EmployeesRepository>();

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
