using System.Net;
using System.Numerics;

namespace TT_LTS_EDU.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int AccountID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Account? Account { get; set; }
        public List<Order>? ListOrder { get; set; }
        public List<ProductReview>? ListProductReview { get; set; }
        public List<Cart>? ListCart { get; set; }
    }
}
