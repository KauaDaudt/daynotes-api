using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DayNotes.API.Data;
using DayNotes.API.Models;
using DayNotes.API.DTOs;
using System.Security.Claims;
namespace DayNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(CreateNoteDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            return Unauthorized();
        }

        var note = new Note
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = int.Parse(userId),
            CreatedAt = DateTime.UtcNow
        };

        _context.Notes.Add(note);
        _context.SaveChanges();

        return Created("", note);
    }
    [HttpGet]
public IActionResult Get()
{
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (userId is null)
    {
        return Unauthorized();
    }

    var notes = _context.Notes
        .Where(n => n.UserId == int.Parse(userId))
        .ToList();

    return Ok(notes);
}
[HttpPut("{id}")]
public IActionResult Update(int id, CreateNoteDto dto)
{
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (userId is null)
    {
        return Unauthorized();
    }

    var note = _context.Notes.FirstOrDefault(n => n.Id == id);

    if (note is null)
    {
        return NotFound();
    }

   
    if (note.UserId != int.Parse(userId))
    {
        return Forbid();
    }

    note.Title = dto.Title;
    note.Content = dto.Content;
    note.UpdatedAt = DateTime.UtcNow;

    _context.SaveChanges();

    return Ok(note);
}
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (userId is null)
    {
        return Unauthorized();
    }

    var note = _context.Notes.FirstOrDefault(n => n.Id == id);

    if (note is null)
    {
        return NotFound();
    }


    if (note.UserId != int.Parse(userId))
    {
        return Forbid();
    }

    _context.Notes.Remove(note);
    _context.SaveChanges();

    return NoContent();

}

}