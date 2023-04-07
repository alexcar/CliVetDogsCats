namespace Application.Exceptions
{
    public sealed class EmailAlreadyRegisteredException : BadRequestException
    {
        public EmailAlreadyRegisteredException(string entityName, string email)
            : base($"Já existe um {entityName} cadastrado com o email: {email}.")
        {
        }
    }
}
