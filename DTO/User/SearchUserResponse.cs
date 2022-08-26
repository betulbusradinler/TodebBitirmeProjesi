﻿using Models.Entities;
using System;

namespace DTO.User
{
    public class SearchUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Email { get; set; }
        public string VehicleNo { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }
        //public Flat Flat { get; set; }
        public UserRole Role { get; set; }
    }
}
