namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
