namespace AutoPark.DAL.Entities
{
    public class OrderPart
    {
        public int Id { get; set; }
        public int PartsNumber { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}