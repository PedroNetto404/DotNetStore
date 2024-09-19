using System;

namespace DotNetStore.ApplicationCore.Exceptions;

public sealed class DomainException
(
    string code,
    string message
) : Exception(message)
{
    public string Code { get; } = code;

    public static void GreatherThan
    (
        int value,
        int expected,
        string code,
        string message
    )
    {
        if (value <= expected) // !(value > expected)
        {
            throw new DomainException(code, message);
        }
    }

    public static void NotEqual<T>
    (
        T toCompare,
        T notEqual,
        string code,
        string message
    )
        where T : notnull
    {
        if (toCompare.Equals(notEqual))
        {
            throw new DomainException
            (
                code,
                message
            );
        }
    }
}
