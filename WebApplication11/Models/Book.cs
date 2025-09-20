using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    public string Genre { get; set; }

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public List<Comment> Comments { get; set; } = new();
}