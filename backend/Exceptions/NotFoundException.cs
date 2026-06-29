using Microsoft.AspNetCore.Http;

namespace Progredi.Exceptions;

public class NotFoundException(string message) : AppException(message, StatusCodes.Status404NotFound);