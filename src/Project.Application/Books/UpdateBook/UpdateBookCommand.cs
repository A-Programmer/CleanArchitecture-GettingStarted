using MediatR;

namespace Project.Application.Books.UpdateBook;

public sealed record UpdateBookCommand(Guid Id,
    string Title,
    string Description,
    string Author) : IRequest<UpdateBookResponse>;