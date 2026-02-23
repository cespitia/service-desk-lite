using System.ComponentModel.DataAnnotations;

namespace ServiceDeskLite.Models;

public class User
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string Role { get; set; } = "Technician"; // Admin | Technician

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}