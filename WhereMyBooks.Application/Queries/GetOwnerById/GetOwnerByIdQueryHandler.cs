using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetOwnerById;

public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerDetailsViewModel>
{
    private readonly IOwnerRepository _repository;

    public GetOwnerByIdQueryHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OwnerDetailsViewModel> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var owner = await _repository.GetByIdAsync(request.Id);

            if (owner is null)
            {
                throw new NotFoundException();
            }

            var ownerDetailViewModel = OwnerMapper.MapToOwnerDetailsViewModel(owner);
            return ownerDetailViewModel;
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