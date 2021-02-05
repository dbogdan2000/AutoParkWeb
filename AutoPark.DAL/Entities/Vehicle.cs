using System;
using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }
        public Colors Color { get; set; }
        public int Volume { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}