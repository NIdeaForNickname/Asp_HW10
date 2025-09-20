using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;

namespace WebApplication11.ViewComponents;

public class CommentsViewComponent : ViewComponent
{
    private readonly AppDbContext _db;
    public CommentsViewComponent(AppDbContext db) { _db = db; }

    public async Task<IViewComponentResult> InvokeAsync(int bookId)
    {
        var comments = await _db.Comments
            .Where(c => c.BookId == bookId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
        ViewBag.BookId = bookId;
        return View(comments);
    }
}