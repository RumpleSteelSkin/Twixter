namespace Core.CrossCuttingConcerns.Exceptions;
public class NotFoundException(string message) : Exception(message);