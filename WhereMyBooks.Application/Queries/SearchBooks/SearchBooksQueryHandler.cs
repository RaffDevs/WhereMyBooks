using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Services;

namespace WhereMyBooks.Application.Queries.SearchBooks;

public class SearchBooksQueryHandler : IRequestHandler<SearchBooksQuery, List<BookDetailViewModel>>
{
    private readonly IBookService _bookService;

    public SearchBooksQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<List<BookDetailViewModel>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookService.SearchBooks(request.Title, request.IdShelf);

            if (books is null)
            {
                throw new NotFoundException();
            }

            return books.Select(b => BookMapper.MapToBookDetailViewModel(b))
                .ToList();
        }
        catch (NotFoundException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}