using System.ComponentModel.DataAnnotations;

namespace ServiceDeskLite.Models;

public class TicketComment
{
    public int Id { get; set; }

    [Required, StringLength(1200)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public int TicketId { get; set; }
    public Ticket? Ticket { get; set; }
}