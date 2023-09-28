namespace TT_LTS_EDU.Handle.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailID { get; set; }
        public double PriceTotal { get; set; }
        public int Quantity { get; set; }
        public ProductDTO? ProductDTO { get; set; }
    }
}
