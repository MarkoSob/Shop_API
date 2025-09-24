namespace Shop_DAL.Models
{
    public class Order : BaseModel
    {
        public string Number { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
