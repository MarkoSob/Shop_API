namespace Shop_DAL.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string ArticleNumber { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
