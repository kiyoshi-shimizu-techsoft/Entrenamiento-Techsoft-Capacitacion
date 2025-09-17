using Bisoft.Entrenamiento.Aplicacion.Services;
using Bisoft.Entrenamiento.Dominio.Repositories;
using Bisoft.Entrenamiento.Infraestructura.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bisoft.Entrenamiento.Consola;

internal static class Program
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddScoped<IPacienteRepository, PacienteSqliteRepository>();
        builder.Services.AddScoped<PacienteService>();
        var app = builder.Build();


        Console.WriteLine("Hello, World!");
        var service = app.Services.CreateScope().ServiceProvider.GetRequiredService<PacienteService>();
        var id = await service.CrearPaciente("Juan Perez", "555-1234", "ejemplo@hotmail.com");

        var ejemplo = $"Paciente creado con id {id}.";
        Console.WriteLine(ejemplo);

        await app.RunAsync();
    }
}
