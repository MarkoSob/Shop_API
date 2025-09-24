namespace Shop_DAL.Models
{
    public class Customer : BaseModel
    {
        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}
