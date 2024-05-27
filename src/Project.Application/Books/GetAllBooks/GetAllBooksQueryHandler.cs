using MediatR;
using Project.Domain.Contracts;
using Project.Domain.Models.Books;

namespace Project.Application.Books.GetAllBooks;

public sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksListItemResponse>>
{
    private readonly IBooksRepository _booksRepository;

    public GetAllBooksQueryHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository 
                           ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    public async Task<IEnumerable<GetAllBooksListItemResponse>> Handle(GetAllBooksQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Book> books = await 
            _booksRepository
            .GetAllAsync(cancellationToken);
        
        return books.Select(b => new GetAllBooksListItemResponse(b.Id, b.Title, b.Author));
    }
}