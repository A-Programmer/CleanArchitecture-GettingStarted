using MediatR;

namespace Project.Application.Books.GetAllBooks;

public sealed record GetAllBooksQuery() : IRequest<IEnumerable<GetAllBooksListItemResponse>>;