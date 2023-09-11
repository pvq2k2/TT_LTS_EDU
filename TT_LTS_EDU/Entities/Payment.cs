namespace TT_LTS_EDU.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Order>? ListOrder { get; set; }
    }
}
