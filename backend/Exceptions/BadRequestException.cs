using Microsoft.AspNetCore.Http;

namespace Progredi.Exceptions;

public class BadRequestException(string message) : AppException(message, StatusCodes.Status400BadRequest);