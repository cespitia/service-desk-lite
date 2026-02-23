using System.ComponentModel.DataAnnotations;

namespace ServiceDeskLite.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string Status { get; set; } = "Open"; // Open | InProgress | Closed

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    [Display(Name = "Assigned To")]
    public int UserId { get; set; }
    public User? User { get; set; }

    public ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}