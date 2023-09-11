namespace TT_LTS_EDU.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string StatusName { get; set; } = string.Empty;

        public List<Order>? ListOrder { get; set; }
    }
}
