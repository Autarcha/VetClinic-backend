﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Adress Adress { get; set; }
    }
}