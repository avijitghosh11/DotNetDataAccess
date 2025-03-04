﻿namespace DotNetCore.MongoDB.EFCore.API.Models
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Pin { get; set; }
    }
}
