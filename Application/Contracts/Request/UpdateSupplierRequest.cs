namespace Application.Contracts.Request
{
    public class UpdateSupplierRequest : SupplierRequest
    {
        public Guid Id { get; set; }
        public UpdateAddressRequest Address { get; set; }
    }
}
