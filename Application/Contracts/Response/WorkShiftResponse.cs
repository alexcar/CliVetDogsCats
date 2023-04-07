namespace Application.Contracts.Response
{
    public class WorkShiftResponse
    {
        public WorkShiftResponse()
        {
            
        }
        public WorkShiftResponse(
            Guid id, bool monday, byte? mondayFrom, byte? mondayTo, 
            bool tuesday, byte? tuesdayFrom, byte? tuesdayTo, 
            bool wednesday, byte? wednesdayFrom, byte? wednesdayTo, 
            bool thursday, byte? thursdayFrom, byte? thursdayTo, 
            bool friday, byte? fridayFrom, byte? fridayTo, 
            bool saturday, byte? saturdayFrom, byte? saturdayTo, 
            bool sunday, byte? sundayFrom, byte? sundayTo)
        {
            Id = id;
            Monday = monday;
            MondayFrom = mondayFrom;
            MondayTo = mondayTo;
            Tuesday = tuesday;
            TuesdayFrom = tuesdayFrom;
            TuesdayTo = tuesdayTo;
            Wednesday = wednesday;
            WednesdayFrom = wednesdayFrom;
            WednesdayTo = wednesdayTo;
            Thursday = thursday;
            ThursdayFrom = thursdayFrom;
            ThursdayTo = thursdayTo;
            Friday = friday;
            FridayFrom = fridayFrom;
            FridayTo = fridayTo;
            Saturday = saturday;
            SaturdayFrom = saturdayFrom;
            SaturdayTo = saturdayTo;
            Sunday = sunday;
            SundayFrom = sundayFrom;
            SundayTo = sundayTo;
        }

        public Guid Id { get; set; }
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
