using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using FirstWebApplication.Data;

namespace FirstWebApplication.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FirstWebApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FirstWebApplicationContext>>()))
            {
                // Look for any games.
                if (context.VideoGame.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Name = "Mario Bros",
                        ReleaseDate = DateTime.Parse("1999-4-15"),
                        Genre = "Aventure/Plateforme",
                        Platform = "Nintendo",
                        Rating = "A"
                    },
                    new VideoGame
                    {
                         Name = "Halo 5 : Guardians",
                         ReleaseDate = DateTime.Parse("2015-10-27"),
                         Genre = "Shooter/FPS",
                         Platform = "Xbox One",
                         Rating = "D"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
