namespace Application.Contracts.Request
{
    public class WorkShiftRequest
    {
        public bool Monday { get; set; }
        public byte? MondayFrom { get; set; }
        public byte? MondayTo { get; set; }
        public bool Tuesday { get; set; }
        public byte? TuesdayFrom { get; set; }
        public byte? TuesdayTo { get; set; }
        public bool Wednesday { get; set; }
        public byte? WednesdayFrom { get; set; }
        public byte? WednesdayTo { get; set; }
        public bool Thursday { get; set; }
        public byte? ThursdayFrom { get; set; }
        public byte? ThursdayTo { get; set; }
        public bool Friday { get; set; }
        public byte? FridayFrom { get; set; }
        public byte? FridayTo { get; set; }
        public bool Saturday { get; set; }
        public byte? SaturdayFrom { get; set; }
        public byte? SaturdayTo { get; set; }
        public bool Sunday { get; set; }
        public byte? SundayFrom { get; set; }
        public byte? SundayTo { get; set; }
    }
}
