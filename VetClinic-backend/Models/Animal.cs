﻿namespace VetClinic_backend.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specie { get; set; }

    }
}