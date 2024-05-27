using System.ComponentModel.DataAnnotations;

namespace Project.Application.Books.CreateBook;

public record CreateBookRequest([Required, Length(5, 150)] string Title,
    [Required] string Description,
    [Required] string Author);