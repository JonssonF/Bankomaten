namespace Labb1___LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        //Navigational Propertys
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }

    public enum OrderStatus
    {
        Processing,
        Shipped,
        Delivered,
    }
}
