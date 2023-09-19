namespace SweetDate.Domain.Enum;

public enum StatusCode
{
    OK = 200,
    InternalServerError = 500,
    PersonNotFound = 0,
    UserAlreadyExists = 2,
    UserNotFound = 1,
}