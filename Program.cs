using btw_api.Database;
using btw_api.Repository;
using btw_api.Services;
using btw_api.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(policy=> {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// Añade el contexto de la base de datos (importante)
builder.Services.AddDbContext<BtwApiContext>(options =>
{
    var c = builder.Configuration.GetConnectionString("MySqlConnection"); // Obtiene el connStr de las properties
    options.UseMySql(c, ServerVersion.AutoDetect(c)); // Pomelo.EntityFramework provee el metodo UseMySql
});

var app = builder.Build();
app.UseCors();

app.MapGet("/users/index", async (IUserService svc) => {
    return svc.GetUsers();
});

app.MapGet("/users/getRoles", async (IUserService svc) => {
    return svc.GetRoles();
});

app.MapPost("/users/create", async ([FromBody] User u, IUserService svc) => {
    if (u == null || u.Name == null) return Results.BadRequest(u);

	try
	{
        await svc.CreateUser(u);
        return Results.Created("/users/create", new { status="created", model=u });
    }
	catch (Exception e)
	{
		return Results.Problem(e.Message, statusCode: 500);
	}
});

app.MapDelete("/users/delete/{id:int}", async (int id, IUserService svc) =>
{
    try
    {
        await svc.DeleteUser(id);
        return Results.Ok();
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message, statusCode: 500);
    }
});

app.Run();