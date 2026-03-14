namespace backend_shopapp.Exceptions
{
    public abstract class HttpErrorException : Exception
    {
        public int StatusCode { get; }

        protected HttpErrorException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : HttpErrorException
    {
        public NotFoundException(string message)
            : base(message, StatusCodes.Status404NotFound)
        {
        }
    }

    public class ConflictException : HttpErrorException
    {
        public ConflictException(string message)
            : base(message, StatusCodes.Status409Conflict)
        {
        }
    }

    public class BadRequestException : HttpErrorException
    {
        public BadRequestException(string message)
            : base(message, StatusCodes.Status400BadRequest)
        {
        }
    }
    public class UnauthorizedException : HttpErrorException
    {
        public UnauthorizedException(string message = "Unauthorized")
            : base(message, StatusCodes.Status401Unauthorized)
        {
        }
    }

    public class ForbiddenException : HttpErrorException
    {
        public ForbiddenException(string message = "Forbidden")
            : base(message, StatusCodes.Status403Forbidden)
        {
        }
    }
}

