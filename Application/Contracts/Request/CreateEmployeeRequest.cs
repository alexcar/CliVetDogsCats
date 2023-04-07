namespace Application.Contracts.Request
{
    public class CreateEmployeeRequest : EmployeeRequest
    {
        public CreateAddressRequest Address { get; set; }
        public CreateWorkShiftRequest WorkShift { get; set; }
    }
}
