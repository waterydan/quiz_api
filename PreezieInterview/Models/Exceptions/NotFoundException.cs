using System;

namespace PreezieInterview.Api.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

#nullable enable
        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
#nullable disable

    }
}
