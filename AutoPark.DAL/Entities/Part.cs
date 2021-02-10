using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public string Part_Name { get; set; }

        public ICollection<OrderPart> OrdersPart { get; set; }
    }
}