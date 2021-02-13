using System;
using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model_Name { get; set; }
        public string Registration_Number { get; set; }
        public int Weight { get; set; }
        public int Manufacture_Year { get; set; }
        public int Mileage { get; set; }
        public Colors Color { get; set; }
        public int Volume { get; set; }

        public int Vehicle_Type_Id { get; set; }
        public VehicleType VehicleType { get; set; }
        
        public ICollection<Order> Orders { get; set; }


        public double GetCalcTaxPerMonth()
        {
            return Weight * 0.0013 + VehicleType.Tax_Coefficient * 30 + 5;
        }
        
        
    }
}