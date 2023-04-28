namespace Application.Contracts.Request
{
    public class UpdateTutorRequest : TutorRequest
    {
        public Guid Id { get; set; }
        public UpdateAddressRequest Address { get; set; }
    }
}
