using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            Console.WriteLine("--> Applying Migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() {Name = "Dot net", Publisher = "MS", Cost = "Free"},
                    new Platform() {Name = "Dot net1", Publisher = "MS1", Cost = "100"},
                    new Platform() {Name = "Dot net2", Publisher = "MS2", Cost = "10"}
                );
                

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
