namespace Application.Exceptions
{
    public sealed class CpfAlreadyRegisteredException : BadRequestException
    {
        public CpfAlreadyRegisteredException(string entityName, string cpf)
            : base($"Já existe um {entityName} cadastrado com o CPF: {cpf}.")
        {

        }
    }
}
