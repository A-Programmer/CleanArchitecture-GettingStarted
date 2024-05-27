using MediatR;
using Project.Domain.Models.Books;

namespace Project.Application.Books.CreateBook;

public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly IBooksRepository _booksRepository;

    public CreateBookCommandHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository
                           ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    public async Task<Guid> Handle(CreateBookCommand request,
        CancellationToken cancellationToken)
    {
        Book book = new(request.Title,
            request.Description,
            request.Author);

        await _booksRepository.AddAsync(book,
            cancellationToken);

        await _booksRepository
            .SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}