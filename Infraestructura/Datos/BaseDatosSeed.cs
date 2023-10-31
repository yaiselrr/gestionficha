using System.Text.Json;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Datos
{
    public class BaseDatosSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Producto.Any())
                {
                    var productoData = File.ReadAllText("../Infraestructura/Datos/SeedData/productos.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData);

                    foreach (var item in productos)
                    {
                        await context.Producto.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Persona.Any())
                {
                    var personaData = File.ReadAllText("../Infraestructura/Datos/SeedData/personas.json");
                    var personas = JsonSerializer.Deserialize<List<Persona>>(personaData);

                    foreach (var item in personas)
                    {
                        await context.Persona.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BaseDatosSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}