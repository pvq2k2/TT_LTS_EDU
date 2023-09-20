namespace TT_LTS_EDU.Handle.Request.ProductRequest
{
    public class CreateProductRequest
    {
        public string? NameProduct { get; set; }
        public int ProductTypeID { get; set; }
        public double Price { get; set; }
        public IFormFile? AvatarImageProduct { get; set; }
        public string? Title { get; set; }
        public int? Discount { get; set; }
    }
}
