using MediatR;
using WhereMyBooks.Core.Enums;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.UpdateMarkup;

public class UpdateMarkupCommandHandler : IRequestHandler<UpdateMarkupCommand>
{
    private readonly IMarkupRepository _repository;

    public UpdateMarkupCommandHandler(IMarkupRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateMarkupCommand request, CancellationToken cancellationToken)
    {
        var markup = await _repository.GetByIdAsync(request.Id);
        
        if (markup is null)
        {
            throw new NotImplementedException();
        }
        markup.SetContent(request.Model.Content);
        markup.SetPage(request.Model.Page);
        markup.SetMarkupType(request.Model.Type);
        await _repository.UpdateAsync(markup);
    }
}