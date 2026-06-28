using Microsoft.AspNetCore.Http;

namespace Progredi.Exceptions;

public class UnauthorizedException(string message) : AppException(message, StatusCodes.Status401Unauthorized);