using MySql.Data.MySqlClient;
using NetCoreApiMySQL.Data;
using NetCoreApiMySQL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* ==================== Metodo UNO para hacer la conexion a la base de datos / Se hace una conexion nueva cada que se llama al repo... bueno para pruebas ==================== */

NetCoreApiMySQL.Data.MySqlConfiguration mySqlConfiguration = new NetCoreApiMySQL.Data.MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySqlConfiguration);  // De esta manera tenemos siempre la cadena de conexion

/* ==================== Metodo DOS para hacer la conexion a la base de datos / Hace una unica conexion... bueno para deploy de la app ==================== */

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();  // Al contenedor de dependencias le damos acceso al repositorio

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
