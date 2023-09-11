using System;

namespace TT_LTS_EDU.Entities
{
    public class Order : BaseEntity
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public double OriginalPrice { get; set; }
        public double ActualPrice { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int OrderStatusID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Payment? Payment { get; set; }
        public User? User { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public List<OrderDetail>? ListOrderDetail { get; set; }
    }
}
