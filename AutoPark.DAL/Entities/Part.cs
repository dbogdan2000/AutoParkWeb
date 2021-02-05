using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public string PartName { get; set; }

        public ICollection<OrderPart> OrdersPart { get; set; }
    }
}