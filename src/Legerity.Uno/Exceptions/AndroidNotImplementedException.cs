namespace Legerity.Uno.Exceptions;

using System;

/// <summary>
/// Defines an exception thrown when code is called for Android but is not implemented.
/// </summary>
public class AndroidNotImplementedException : NotImplementedException
{
    /// <summary>Initializes a new instance of the <see cref="AndroidNotImplementedException" /> class with default properties.</summary>
    public AndroidNotImplementedException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AndroidNotImplementedException" /> class with a specified error message.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public AndroidNotImplementedException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AndroidNotImplementedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
    public AndroidNotImplementedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}