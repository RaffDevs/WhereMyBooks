using MediatR;
using WhereMyBooks.Core.Enums;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IBookRepository _repository;

    public UpdateBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id);
        if (book is null)
        {
            throw new NotImplementedException();
        }
        
        book.SetTitle(request.Model.Title);
        book.SetDescription(request.Model.Description);
        book.SetAuthors(request.Model.Authors);
        book.SetPublisher(request.Model.Publisher);
        book.SetPageCount(request.Model.PageCount);
        book.SetIsnb(request.Model.Isbn);
        book.SetBookType((BookType)request.Model.BookType);
        book.SetThumbnailLink(request.Model.ThumbnailLink);
        book.SetThumbnailSmallLink(request.Model.SmallThumbnailLink);

        await _repository.UpdateAsync(book);
    }
}