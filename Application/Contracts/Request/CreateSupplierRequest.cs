namespace Application.Contracts.Request
{
    public class CreateSupplierRequest : SupplierRequest
    {
        public CreateAddressRequest Address { get; set; }
    }
}
