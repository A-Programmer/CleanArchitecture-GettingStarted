using MediatR;
using Project.Common.CustomExceptions;
using Project.Common.CustomExceptions.Books;
using Project.Domain.Contracts;
using Project.Domain.Models.Books;

namespace Project.Application.Books.DeleteBook;

public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBooksRepository _booksRepository;

    public DeleteBookCommandHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository 
                      ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        Book book = await _booksRepository.GetByIdAsync(request.Id, cancellationToken);

        if (book is null)
            throw new BookNotFoundException(request.Id.ToString());
        
        _booksRepository.Remove(book);

        await _booksRepository
            .SaveChangesAsync(cancellationToken);
    }
}