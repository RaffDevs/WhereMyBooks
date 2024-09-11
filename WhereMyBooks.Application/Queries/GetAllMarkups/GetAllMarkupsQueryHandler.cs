using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetAllMarkups;

public class GetAllMarkupsQueryHandler : IRequestHandler<GetAllMarkupsQuery, List<MarkupViewModel>>
{
    private readonly IMarkupRepository _repository;

    public GetAllMarkupsQueryHandler(IMarkupRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MarkupViewModel>> Handle(GetAllMarkupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var markups = await _repository.GetAllAsync(request.IdBook);

            var markupsViewModel = markups.Select(
                MarkupMapper.MapToMarkupViewModel
            ).ToList();

            return markupsViewModel;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}