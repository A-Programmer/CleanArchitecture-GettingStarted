using MediatR;
using Project.Common.CustomExceptions.Books;
using Project.Domain.Contracts;
using Project.Domain.Models.Books;

namespace Project.Application.Books.GetBookById;

public sealed class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdResponse>
{
    private readonly IBooksRepository _booksRepository;

    public GetBookByIdQueryHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository
                           ?? throw new ArgumentNullException(nameof(booksRepository));
    }
    
    public async Task<GetBookByIdResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        Book book = await _booksRepository
            .GetByIdAsync(request.Id,
                cancellationToken);

        if (book is null)
            throw new BookNotFoundException(request.Id.ToString());

        return new(book.Id, book.Title, book.Description, book.Author);
    }
}