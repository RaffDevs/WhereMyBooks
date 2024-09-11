using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailViewModel>
{
    private readonly IBookRepository _repository;

    public GetBookByIdQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookDetailViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _repository.GetByIdAsync(request.Id);
            if (book is null)
            {
                throw new NotFoundException();
            }

            var bookViewModel = BookMapper.MapToBookDetailViewModel(book);
            return bookViewModel;
        }
        catch (NotFoundException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}