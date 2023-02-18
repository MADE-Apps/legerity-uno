namespace Legerity.Uno.Exceptions;

using System;

/// <summary>
/// Defines an exception thrown when code is called for Web but is not implemented.
/// </summary>
public class WebNotImplementedException : NotImplementedException
{
    /// <summary>Initializes a new instance of the <see cref="WebNotImplementedException" /> class with default properties.</summary>
    public WebNotImplementedException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WebNotImplementedException" /> class with a specified error message.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public WebNotImplementedException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WebNotImplementedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
    public WebNotImplementedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}