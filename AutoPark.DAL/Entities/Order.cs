using System.Collections.Generic;

namespace AutoPark.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int Vehicle_Id { get; set; }
        public Vehicle Vehicle { get; set; }

        public ICollection<OrderPart> OrderParts { get; set; }
    }
}