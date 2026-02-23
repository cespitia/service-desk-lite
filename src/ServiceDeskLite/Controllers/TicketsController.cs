using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceDeskLite.Data;
using ServiceDeskLite.Models;

namespace ServiceDeskLite.Controllers;

public class TicketsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TicketsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Tickets
    public async Task<IActionResult> Index()
    {
        var tickets = await _context.Tickets
            .Include(t => t.User)
            .OrderByDescending(t => t.CreatedAtUtc)
            .ToListAsync();

        return View(tickets);
    }

    // GET: /Tickets/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var ticket = await _context.Tickets
            .Include(t => t.User)
            .Include(t => t.Comments.OrderByDescending(c => c.CreatedAtUtc))
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket == null) return NotFound();
        return View(ticket);
    }

    // GET: /Tickets/Create
    public IActionResult Create()
    {
        PopulateUsersDropDown();
        return View(new Ticket());
    }

    // POST: /Tickets/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        if (!ModelState.IsValid)
        {
            PopulateUsersDropDown(ticket.UserId);
            return View(ticket);
        }

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Tickets/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null) return NotFound();

        PopulateUsersDropDown(ticket.UserId);
        return View(ticket);
    }

    // POST: /Tickets/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ticket ticket)
    {
        if (id != ticket.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            PopulateUsersDropDown(ticket.UserId);
            return View(ticket);
        }

        _context.Update(ticket);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // POST: /Tickets/SetStatus/5?status=Closed
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetStatus(int id, string status)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null) return NotFound();

        var allowed = new[] { "Open", "InProgress", "Closed" };
        if (!allowed.Contains(status)) return BadRequest();

        ticket.Status = status;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id });
    }

    private void PopulateUsersDropDown(int? selectedUserId = null)
    {
        var users = _context.Users
            .OrderBy(u => u.Role)
            .ThenBy(u => u.Name)
            .ToList();

        ViewBag.UserId = new SelectList(users, "Id", "Name", selectedUserId);
    }
}