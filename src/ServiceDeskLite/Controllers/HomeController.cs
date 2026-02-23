using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceDeskLite.Data;

namespace ServiceDeskLite.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var open = await _context.Tickets.CountAsync(t => t.Status == "Open");
        var inProgress = await _context.Tickets.CountAsync(t => t.Status == "InProgress");
        var closed = await _context.Tickets.CountAsync(t => t.Status == "Closed");

        ViewBag.OpenCount = open;
        ViewBag.InProgressCount = inProgress;
        ViewBag.ClosedCount = closed;

        return View();
    }
}