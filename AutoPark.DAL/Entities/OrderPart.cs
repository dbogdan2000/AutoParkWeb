namespace AutoPark.DAL.Entities
{
    public class OrderPart
    {
        public int Id { get; set; }
        public int Parts_Number { get; set; }

        public int Order_Id { get; set; }
        public Order Order { get; set; }
        public int Part_Id { get; set; }
        public Part Part { get; set; }
    }
}