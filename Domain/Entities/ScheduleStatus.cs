﻿namespace Domain.Entities
{
    public class ScheduleStatus : BaseEntity
    {
        public ScheduleStatus()
        {
            
        }
        public ScheduleStatus(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
