﻿using System.Text.Json;

namespace MyGameCity.DataModel
{
    public class Games
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Ammount { get; set; }
        public string Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Review Review { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }  
}
