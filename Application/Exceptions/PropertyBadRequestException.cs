namespace Application.Exceptions
{
    public class PropertyBadRequestException : BadRequestException
    {
        public PropertyBadRequestException(string message) : base(message)
        {
        }
    }
}
