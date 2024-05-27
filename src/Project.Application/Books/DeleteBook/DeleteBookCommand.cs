using MediatR;

namespace Project.Application.Books.DeleteBook;

public sealed record DeleteBookCommand(Guid Id) : IRequest;