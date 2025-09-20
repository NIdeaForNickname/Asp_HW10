using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;

namespace WebApplication11.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext _db;
    public BookController(AppDbContext db) { _db = db; }

    public async Task<IActionResult> Index()
    {
        var books = await _db.Books.AsNoTracking().ToListAsync();
        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _db.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddComment(int bookId, string authorName, string content)
    {
        if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(content))
        {
            return RedirectToAction("Details", new { id = bookId });
        }

        _db.Comments.Add(new Models.Comment
        {
            AuthorName = authorName,
            Content = content,
            BookId = bookId,
            CreatedAt = DateTime.UtcNow
        });
        await _db.SaveChangesAsync();

        return RedirectToAction("Details", new { id = bookId });
    }
}