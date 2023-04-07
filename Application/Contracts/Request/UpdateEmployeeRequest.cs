namespace Application.Contracts.Request
{
    public class UpdateEmployeeRequest : EmployeeRequest
    {
        public Guid Id { get; set; }                
        public UpdateAddressRequest Address { get; set; }
        public UpdateWorkShiftRequest WorkShift { get; set; }
    }
}
