using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetMarkupById;

public class GetMarkupByIdQueryHandler : IRequestHandler<GetMarkupByIdQuery, MarkupViewModel>
{
    private readonly IMarkupRepository _repository;

    public GetMarkupByIdQueryHandler(IMarkupRepository repository)
    {
        _repository = repository;
    }

    public async Task<MarkupViewModel> Handle(GetMarkupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var markup = await _repository.GetByIdAsync(request.Id);
            if (markup is null)
            {
                throw new NotImplementedException();
            }

            var markupViewModel = MarkupMapper.MapToMarkupViewModel(markup);
            return markupViewModel;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}