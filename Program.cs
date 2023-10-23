using Microsoft.EntityFrameworkCore;
using MorningStartApi.Data;
using MorningStartApi.Repository;
using MorningStartApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DataBase");


builder.Services.AddDbContext<SistemaMercadoriasDBContex>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
        });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


