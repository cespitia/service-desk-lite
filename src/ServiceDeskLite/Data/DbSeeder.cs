using Microsoft.EntityFrameworkCore;
using ServiceDeskLite.Models;

namespace ServiceDeskLite.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Name = "Admin", Role = "Admin" },
                new User { Name = "Tech One", Role = "Technician" },
                new User { Name = "Tech Two", Role = "Technician" }
            );

            await context.SaveChangesAsync();
        }
    }
}