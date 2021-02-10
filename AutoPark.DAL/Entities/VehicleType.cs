using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type_Name { get; set; }
        public double Tax_Coefficient { get; set; }
        
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}