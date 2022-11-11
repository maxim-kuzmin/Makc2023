namespace Makc2023.Services.Sample.Domain.Exceptions;

/// <summary>
/// Исключение в домене.
/// </summary>
public class DomainException : Exception
{
    public DomainException()
    { }

    public DomainException(string message)
        : base(message)
    { }

    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}