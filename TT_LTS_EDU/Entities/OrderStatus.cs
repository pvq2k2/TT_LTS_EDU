namespace TT_LTS_EDU.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string? StatusName { get; set; }

        public List<Order>? ListOrder { get; set; }
    }
}
