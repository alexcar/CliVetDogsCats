﻿namespace Domain.Entities
{
    public class DayWeek : BaseEntity
    {
        public DayWeek()
        {
            
        }
        public DayWeek(string? name)
        {
            Name = name;
        }
        
        public string? Name { get; set; }        
    }
}
