namespace Project.Common.CustomExceptions.Books;

public sealed class BookNotFoundException : Exception
{
    public BookNotFoundException(string bookId)
        : base($"The book with Id {bookId} could not be found.")
    {

    }
}