namespace Labb1___LINQ.Models
{
    public class OrderDetail
    {

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        //Navigational Property
        public Product Product { get; set; } = null!;

        public Order Order { get; set; } = null!;



    }
}
