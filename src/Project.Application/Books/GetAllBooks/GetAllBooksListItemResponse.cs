namespace Project.Application.Books.GetAllBooks;

public sealed record GetAllBooksListItemResponse(Guid Id,
    string Title,
    string Author);