namespace Application.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(string entityName, Guid? id) 
            : base($"O {entityName} com o {id} não existe.")
        {
        }
    }
}
