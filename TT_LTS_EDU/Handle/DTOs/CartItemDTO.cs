namespace TT_LTS_EDU.Handle.DTOs
{
    public class CartItemDTO
    {
        public int CartItemID { get; set; }
        public ProductDTO? ProductDTO { get; set; }
        public int Quantity { get; set; }
    }
}
