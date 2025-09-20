using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public string AuthorName { get; set; }

    [Required]
    [StringLength(1000)]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int BookId { get; set; }
    public Book Book { get; set; }
}