namespace Project.Application.Books.UpdateBook;

public sealed record UpdateBookResponse(Guid Id,
    string Title,
    string Description,
    string Author);