using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Enums;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.CreateMarkup;

public class CreateMarkupCommandHandler : IRequestHandler<CreateMarkupCommand, int>
{
    private readonly IMarkupRepository _markupRepositoryrepository;
    private readonly IBookRepository _bookRepository;

    public CreateMarkupCommandHandler(IMarkupRepository markupRepositoryrepository, IBookRepository bookRepository)
    {
        _markupRepositoryrepository = markupRepositoryrepository;
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateMarkupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _bookRepository.GetByIdAsync(request.Model.IdBook);

            if (book is null)
            {
                throw new NotFoundException();
            }

            var markup = MarkupMapper.MapToMarkup(request.Model);
            var result = await _markupRepositoryrepository.CreateAsync(markup);

            return result.Id;
        }
        catch (NotFoundException exception)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new InternalException(exception.Message);
        }
        
    }
}