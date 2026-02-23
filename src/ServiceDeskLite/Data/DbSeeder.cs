using Microsoft.EntityFrameworkCore;
using ServiceDeskLite.Models;

namespace ServiceDeskLite.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        // Seed Users
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Name = "Admin", Role = "Admin" },
                new User { Name = "Tech One", Role = "Technician" },
                new User { Name = "Tech Two", Role = "Technician" }
            );

            await context.SaveChangesAsync();
        }

        // Seed Tickets
        if (!context.Tickets.Any())
        {
            var users = await context.Users.ToListAsync();
            var techOne = users.First(u => u.Name == "Tech One");
            var techTwo = users.First(u => u.Name == "Tech Two");

            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Title = "VPN connection failing for remote users",
                    Description = "Users report intermittent VPN drops when connected from home networks.",
                    Status = "Open",
                    UserId = techOne.Id
                },
                new Ticket
                {
                    Title = "Email delivery delay in Outlook",
                    Description = "Outgoing emails delayed by 5–10 minutes for internal recipients.",
                    Status = "InProgress",
                    UserId = techTwo.Id
                },
                new Ticket
                {
                    Title = "Password reset portal error",
                    Description = "Portal throws 500 error after security question validation.",
                    Status = "Closed",
                    UserId = techOne.Id
                }
            };

            context.Tickets.AddRange(tickets);
            await context.SaveChangesAsync();

            // Seed Comments
            context.TicketComments.AddRange(
                new TicketComment
                {
                    TicketId = tickets[0].Id,
                    Content = "Initial investigation started. Reviewing VPN gateway logs."
                },
                new TicketComment
                {
                    TicketId = tickets[1].Id,
                    Content = "Reproduced issue in staging. Checking SMTP relay configuration."
                },
                new TicketComment
                {
                    TicketId = tickets[2].Id,
                    Content = "Issue resolved by fixing null reference in password validation service."
                }
            );

            await context.SaveChangesAsync();
        }
    }
}