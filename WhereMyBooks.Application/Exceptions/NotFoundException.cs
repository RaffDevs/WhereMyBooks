namespace WhereMyBooks.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public override string Message { get; }

    public NotFoundException(string? message = "")
    {
        Message = string.IsNullOrEmpty(message)
            ? "Nenhum registro encontrado!"
            : message;
    }

    public static NotFoundException Build(string? message)
    {
        return new NotFoundException(message);
    }
}