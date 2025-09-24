namespace Shop_DAL.DTOs
{
    public class RecentCustomerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LastPurchaseDate { get; set; } = string.Empty;
    }
}
