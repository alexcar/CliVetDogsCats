﻿namespace Domain.Entities
{
    public class Species : BaseEntity
    {
        public Species()
        {
            
        }
        public Species(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
