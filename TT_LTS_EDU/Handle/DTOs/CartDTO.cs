using TT_LTS_EDU.Entities;

namespace TT_LTS_EDU.Handle.DTOs
{
    public class CartDTO
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public List<CartItemDTO>? ListCartItemDTO { get; set; }
    }
}
