using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Books.CreateBook;
using Project.Application.Books.DeleteBook;
using Project.Application.Books.GetAllBooks;
using Project.Application.Books.GetBookById;
using Project.Application.Books.UpdateBook;

namespace Project.Presentation.Controllers;

public sealed class BooksController : BaseController
{
    public BooksController(ISender sender)
        : base(sender)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetAllBooksListItemResponse>>> GetAsync(
        CancellationToken cancellationToken)
    {
        GetAllBooksQuery query = new();

        IEnumerable<GetAllBooksListItemResponse> result = await Sender.Send(query,
            cancellationToken);

        return Ok(result.ToList());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetBookByIdResponse>> GetAsync(Guid id,
        CancellationToken cancellationToken)
    {
        GetBookByIdQuery query = new(id);

        GetBookByIdResponse result = await Sender.Send(query, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult> PostAsync(CreateBookRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateBookCommand command = new(request.Title,
            request.Description,
            request.Author);

        Guid result = await Sender.Send(command, cancellationToken);

        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateBookResponse>> UpdateAsync(Guid id,
        UpdateBookRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateBookCommand command = new(id,
            request.Title,
            request.Description,
            request.Author);

        UpdateBookResponse result = await Sender.Send(command, cancellationToken);

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        DeleteBookCommand command = new(id);

        await Sender.Send(command, cancellationToken);

        return NoContent();
    }
}