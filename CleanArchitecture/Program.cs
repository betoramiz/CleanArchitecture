using CleanArchitecture.Application.AlumnosV2;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.UseCase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUseCase<ObtenerPorNombreUseCase.Request, ObtenerPorNombreUseCase.Response>, ObtenerPorNombreUseCase.UseCase>();
// builder.Services.AddScoped<IUseCase<Crear.Request, Crear.Response>, Crear.UseCase>();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddEntityFrameworkInMemoryDatabase();

var app = builder.Build();

app.MapGet("/api/test", (string nombre, IUseCase<ObtenerPorNombreUseCase.Request, ObtenerPorNombreUseCase.Response> useCase) =>
{
    var request = new ObtenerPorNombreUseCase.Request() { Nombre = nombre };
    var response = useCase.Execute(request);
    return Results.Ok(response);
});

//app.MapGet("/", () => "Alumnos");


app.Run();