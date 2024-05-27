namespace Project.Application.Books.GetBookById;

public sealed record GetBookByIdResponse(Guid Id,
    string Title,
    string Description,
    string Author);