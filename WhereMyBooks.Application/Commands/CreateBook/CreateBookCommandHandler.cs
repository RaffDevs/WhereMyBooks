using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _repository;

    public CreateBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = BookMapper.MapToBook(request.Model);

            var result = await _repository.CreateAsync(book);

            return result.Id;
        }
        catch (Exception exception)
        {
            throw new InternalException(exception.Message);
        }
        
    }
}