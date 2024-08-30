using MediatR;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Application.Queries.GetBookShelfById;

public class GetBookShelfByIdQueryHandler : IRequestHandler<GetBookShelfByIdQuery, BookShelfDetailViewModel>
{
    private readonly IBookShelfRepository _repository;

    public GetBookShelfByIdQueryHandler(IBookShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookShelfDetailViewModel> Handle(GetBookShelfByIdQuery request,
        CancellationToken cancellationToken)
    {
        var bookShelf = await _repository.GetByIdAsync(request.Id);

        if (bookShelf is null)
        {
            throw new NotImplementedException();
        }

        var shelfsViewModel = BookShelfMapper.MapToBookShelfDetailViewModel(bookShelf);

        return shelfsViewModel;
    }
}