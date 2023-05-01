﻿namespace Domain.Entities
{
    public class Race : BaseEntity
    {
        public Race()
        {
            
        }
        public Race(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
