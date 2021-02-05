using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }
        
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}