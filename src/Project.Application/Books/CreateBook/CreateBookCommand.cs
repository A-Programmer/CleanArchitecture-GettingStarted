using MediatR;

namespace Project.Application.Books.CreateBook;

public sealed record CreateBookCommand(string Title,
    string Description,
    string Author) : IRequest<Guid>;