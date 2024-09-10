namespace WhereMyBooks.Application.Exceptions;

public sealed class InternalException: Exception
{
    public override string Message { get; }

    public InternalException(string? message) : base(message)
    {
        Message = string.IsNullOrEmpty(message)
            ? "Oops, algo de errado não está certo! Contate o administrador!"
            : $"Eita, ocorreu o seguinte erro: {message}";
    }

    public static InternalException Build(string? message)
    {
        return new InternalException(message);
    }
}