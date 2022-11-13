namespace Makc2023.Services.Sample.Domain.Exceptions;

/// <summary>
/// Фиктивное исключение.
/// </summary>
public class DummyException : Exception
{
    public DummyException()
    { }

    public DummyException(string message)
        : base(message)
    { }

    public DummyException(string message, Exception innerException)
        : base(message, innerException)
    { }
}