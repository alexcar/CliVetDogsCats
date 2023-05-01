namespace Application.Contracts.Request
{
    public class GetVetByDutyDateRequest
    {
        public DateTime dutyDate { get; set; }
        public byte hour { get; set; }
    }
}
