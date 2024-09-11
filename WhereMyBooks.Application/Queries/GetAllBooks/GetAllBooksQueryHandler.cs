using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
{
    private readonly IBookRepository _repository;

    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _repository.GetAllAsync(request.IdShelf);

            var booksViewModel = books
                .Select(BookMapper.MapToBookViewModel)
                .ToList();

            return booksViewModel;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}