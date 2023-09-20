namespace TT_LTS_EDU.Handle.DTOs
{
    public class ProductDTO
    {
        public string? NameProduct { get; set; }
        public double Price { get; set; }
        public string? AvatarImageProduct { get; set; }
        public string? Title { get; set; }
        public int? Discount { get; set; }
        public int Status { get; set; }
        public int NumberOfViews { get; set; } = 0;
    }
}
