using MediatR;

namespace Project.Application.Books.GetBookById;

public sealed record GetBookByIdQuery(Guid Id) : IRequest<GetBookByIdResponse>;