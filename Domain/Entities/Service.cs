namespace Domain.Entities
{
    public class Service : BaseEntity
    {
        public Service()
        {
            
        }
        public Service(string name, decimal saleValue)
        {
            Name = name;
            SaleValue = saleValue;
        }

        public string Name { get; set; }
        public decimal SaleValue { get; set; }
        public List<Schedule> Schedules { get; } = new();
    }
}
