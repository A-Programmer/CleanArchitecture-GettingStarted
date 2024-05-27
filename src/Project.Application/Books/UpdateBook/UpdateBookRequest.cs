using System.ComponentModel.DataAnnotations;

namespace Project.Application.Books.UpdateBook;

public sealed record UpdateBookRequest([Required] string Title,
    [Required] string Description,
    [Required] string Author);