using BookManagement.API;
using BookManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.

builder.Services.AddWebAPIService(builder);
builder.Services.AddInfractstructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elder Connection Platform");
});

app.UseCors("app-cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
