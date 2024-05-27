using MediatR;
using Project.Common.CustomExceptions;
using Project.Common.CustomExceptions.Books;
using Project.Domain.Contracts;
using Project.Domain.Models.Books;

namespace Project.Application.Books.UpdateBook;

public sealed class UpdateBookCommandHandler
    : IRequestHandler<UpdateBookCommand, UpdateBookResponse>
{
    private readonly IBooksRepository _booksRepository;

    public UpdateBookCommandHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository
                           ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    public async Task<UpdateBookResponse> Handle(UpdateBookCommand request,
        CancellationToken cancellationToken)
    {
        Book existingBook = await _booksRepository
            .GetByIdAsync(request.Id,
                cancellationToken);

        if (existingBook is null)
            throw new 
                BookNotFoundException(request.Id.ToString());
        
        existingBook.Update(request.Title,
            request.Description,
            request.Author);

        await _booksRepository
            .SaveChangesAsync(cancellationToken);

        return new UpdateBookResponse(existingBook.Id,
            existingBook.Title,
            existingBook.Description,
            existingBook.Author);
    }
}