namespace Core.CrossCuttingConcerns.Exceptions;

public class AuthorizationException : Exception
{
    private readonly List<string> _errors = [];
    public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

    public AuthorizationException(string message) : base(message)
    {
        _errors.Add(message);
    }

    public AuthorizationException(ICollection<string> errors) : base(BuildErrorMessage(errors))
    {
        _errors.AddRange(errors);
    }

    private static string BuildErrorMessage(ICollection<string> errors)
    {
        return string.Join(Environment.NewLine, errors);
    }
}